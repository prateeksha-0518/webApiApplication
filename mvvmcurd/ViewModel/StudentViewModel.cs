using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using mvvmcurd.Command;
using mvvmcurd.model;
using Wpfcurd.Models;

namespace mvvmcurd.ViewModel
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> students;
        private int currentPage;
        private int totalPages;

        StudentService objStudentService;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }
        private ObservableCollection<Student> studentsList;
        public ObservableCollection<Student> StudentsList
        {
            get
            {
                return studentsList;
            }
            set { studentsList = value; OnPropertyChanged("StudentsList"); }
        }
       


        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
              
                OnPropertyChanged(nameof(CurrentPage));
                LoadData();
            }
        }

        public int TotalPages
        {
            get { return totalPages; }
            set
            {
                totalPages = value;
                OnPropertyChanged(nameof(TotalPages));
            }
        }

        public ICommand PreviousPageCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }

        public StudentsViewModel()
        {
            objStudentService = new StudentService();
            CurrentPage = 1;
            SortField = "Id";
            SortOrder = "Desc";
            // Initialize commands
            PreviousPageCommand = new RelayCommand(PreviousPage);
            NextPageCommand = new RelayCommand(NextPage);
            CurrentStudent = new Student();
            editCommand = new RelayCommand(Edit);
            updateCommand = new RelayCommand(Update);
            SelectedStudent = new Student();
            clearCommand = new RelayCommand(clearData);
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(LoadData);
            deleteCommand = new RelayCommand(Delete);
            // Fetch initial data for the first page
           


            LoadData();
        }
        
        public void LoadData()
        {

            int pageSize = 10;
           
            var students = objStudentService.GetAll(CurrentPage,pageSize,SearchText,SortField,SortOrder);
           
            StudentsList = new ObservableCollection<Student>(students);
           int Totalstudents=objStudentService.GetTotalStudentCount();
            {
                TotalPages=(int)Math.Ceiling((double)Totalstudents/pageSize);
            }
            
        }
    
        private string _SortField;
        public string SortField
        {
            get { return _SortField; }
            set
            {
                _SortField= value;
                OnPropertyChanged(nameof(SortField));
                LoadData();
            }
        }
        private string _SortOrder;
        public string SortOrder
        {
            get { return _SortOrder; }
            set
            {
                _SortOrder = value;
                OnPropertyChanged(nameof(SortOrder));
                LoadData();
            }
        }

        private int totalItems;
        private void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                LoadData();
            }
        }

        private void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                LoadData();


            }
        }
        private RelayCommand clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return clearCommand;
            }
            set
            {
                clearCommand = value;
            }
        }




        public void clearData()
        {

            //currentStudent.StudentId = int.Parse("");
            currentStudent.Name = "";
            currentStudent.Roll = "";


        }
        //Property that holds value of textboxes
        private Student currentStudent;
        public Student CurrentStudent
        {
            get
            { return currentStudent; }
            set
            {
                currentStudent = value; OnPropertyChanged("CurrentStudent");
            }
        }
        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand;
            }
            set
            {
                value = editCommand;
                OnPropertyChanged(nameof(Edit));
            }
        }
        public void Edit()
        {

            if (SelectedStudent != null)
            {
                CurrentStudent = SelectedStudent;
            }
        }
        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; OnPropertyChanged("TotalItems"); }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void Update()
        {
            var IsUpdated = objStudentService.Update(CurrentStudent);

            if (IsUpdated)
            {
                MessageBox.Show("Student Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                LoadData();
                clearData();
            }
            else
            {
                MessageBox.Show("Update failed", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }


        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand;
            }
        }

        private void Save()
        {
            if (currentStudent.StudentId == 0)
            {
                var IsSaved = objStudentService.Add(CurrentStudent);
                if (IsSaved)
                {
                    MessageBox.Show("Student Saved", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LoadData();
                    clearData();
                }
                else
                {
                    MessageBox.Show("Student failed to save", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else

            {
                var IsUpdated = objStudentService.Update(CurrentStudent);

                if (IsUpdated)
                {
                    MessageBox.Show("Student Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LoadData();
                    clearData();
                }
                else
                {
                    MessageBox.Show("Update failed", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand;
            }
            set
            {
                searchCommand = value;
            }

        }
        private int _Age;
        public int Age
        {
            get
            { return _Age; }
            set
            {
                _Age = value; OnPropertyChanged("Age");
              
            }
        }
        private String searchText;
        public string SearchText
        {
            get
            { return searchText; }
            set
            {
                searchText = value; OnPropertyChanged("SearchText");
                currentPage = 1;
                LoadData();
            }
        }
        public void Search()
        {
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }
            else if (SearchText.All(char.IsDigit))
            {
                var objStudent = objStudentService.Search(Convert.ToInt32(SearchText));
                if (objStudent != null && objStudent.Count > 0)
                {
                    StudentsList = new ObservableCollection<Student>(objStudent);
                }
                else
                {
                    StudentsList = null;
                    MessageBox.Show("Student not found", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                var objStudentbyName = objStudentService.SearchbyName(SearchText);
                if (objStudentbyName != null && objStudentbyName.Count > 0)
                {
                    StudentsList = new ObservableCollection<Student>(objStudentbyName);
                }
                else
                {
                    StudentsList = null;
                    MessageBox.Show("Student not found", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }


        private RelayCommand loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                return loadCommand;
            }

        }
       


        private RelayCommand deleteCommand;

      

        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        private void Delete()
        {
            var IsDelete = objStudentService.Delete(CurrentStudent.StudentId);
            if (IsDelete)
            {
                MessageBox.Show("Student Deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                LoadData();

                clearData();
            }
            else
            {
                MessageBox.Show("Student not Deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

