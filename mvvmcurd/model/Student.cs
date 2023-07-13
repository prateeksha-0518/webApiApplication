using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mvvmcurd.model
{
    public class Student : INotifyPropertyChanged,IDataErrorInfo
    {
        

        private int _StudentId;
        public int StudentId
        {
            get => _StudentId;
            set
            {
                _StudentId = value;
                OnPropertyChanged("StudentId");
            }
        }

       

        private int _Age;
        public int Age
        {
            get
            {
                if (DateTime.TryParse(Dateofbirth, out DateTime birthdate))
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - birthdate.Year;
                   
                    return age;
                }
                else
                {
                    return 0;

                }
            }

        }
        public DateTime createddate { get; set; }
        private string  _Dateofbirth;
        public string Dateofbirth
        {
            get => _Dateofbirth;
            set
            {
                _Dateofbirth = value;
                OnPropertyChanged("Dateofbirth");
                OnPropertyChanged("Age");
            }
        }
       
        private string _Name;
        [Required(ErrorMessage = "First name is required.")]
        public string Name
        {
            get => _Name;
            set
            {

                _Name = value;
                OnPropertyChanged("Name");
              
            }
        }

        private string _Roll;


        public string Roll
        {
            get => _Roll;
            set
            {
                _Roll = value;
                OnPropertyChanged("Roll");
               
            }
        }
      
    



public string Error
        {
            get { return null; }
        }

        public string this[string PropertyName]
        {
            get
            {
                string error = string.Empty;

                switch (PropertyName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                            error = "Name cannot be empty";
                        else if (!Regex.IsMatch(Name, @"^[a-zA-Z]+$"))
                        {
                            error = "Should enter alphabets only!!!";
                        }
                        break;
                    case "Roll":
                        if (string.IsNullOrEmpty(Roll))
                            error = "Roll cannot be empty";
                        break;
                }
             
              
                return error;
            }
        }
      


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

    }
}

