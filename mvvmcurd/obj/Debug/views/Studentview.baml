   M S B A M L   `   `   `  ����C  ?mvvmcurd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:mvvmcurd.viewsmvvmcurd.views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 69        mvvmcurd.views.Studentview   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:mvvmcurd.views     5      6sys&clr-namespace:System;assembly=mscorlib     69     � 	Resources  5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource	 �� Path
 �� 
TargetType��%�  '��       '�� �     �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 60   �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      "
 ��6&   .R�5      � .+�5      �� 
��� d �6(   �� 5      $��Center=�6/   $��Center=�6L   6i   5      5      5      �� 5       � ��
 �����6;   �� 5       � ��$
 5,10q�6(    5      P� 5        �@J�IsMouseOver . . �5!      ��  � ��
 �   �63   �� 5"       � ��
 � d �6G   �� 5#       � ��$ 	ExtraBold"�63   5%      5(      5,      .��5-      �  � RowDefinitions 5.   
   �� 5/      $
��Auto �6   �� 50      $
��Auto �6   �� 51      $
��Auto �6   �� 52      $
��Auto �6   �� 53      $
��Auto �6   �� 54      $
��Auto �6   �� 55      $
��Auto �6   �� 56      $
��Auto �6   �� 57       � ColumnDefinitions 59   
   �� 5:      $
��Auto �6   �� 5;      $
��Auto �6   �� 5<      $
��Auto �6   �� 5=      $
��Auto �6   .+�5?   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6/   $��1��6<   $��0 30 0 0q�6L   .+�5@      �� -   5         ��Name$ scrchbtn��5@      $��Search��6(   $
��Left=�6a   $	��Top=�6}   $��95��6�   $��20��6�   ��69   �� $	 SearchCommand�6�   �� 5A      -   5         ��Name$ txtsrch��5A      $
��Left=�6n    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6(   �� $	 
SearchText� �� UpdateSourceTrigger$ PropertyChanged=�.��6�    J� InputBindings 5B      �� 5C      
 �� Key$ Enter��6!    �� Command 6-   �� *SearchCommand+.��5D   )   5E      �� 5F       �� SelectedItem 6   �� $	 	SortField�.@�5G      �� $��	StudentId��6   �� 5H      $
��Name��6   �� 5I      $
��Roll��6   5J      �� 5K       6   �� $	 	SortOrder�.@�5L      �� $��	Ascending��6   �� 5M      $��
Descending��6   5N      5O      &   System.Windows.Controls.DataGrid  5P   
   <my-http://schemas.microsoft.com/wpf/2008/toolkit     5Q      -   5          Name$ 	dgStudent��5P      $��1��6'   $��1��64      CanUserAddRows .     CanUserSortColumns .     AutoGenerateColumns .  ��5S      �� $	 StudentsList� �� Mode$ TwoWay=� 5T      �� $	 SelectedStudent�$ TwoWay=�   Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Student Id��6%      CanUserSort . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $	 	StudentId�6\     5W      $
 Name��6%    63   �� $
	 Name�  5X      $
 Roll��6%    63   �� $
	 Roll�  5Y      $	 Age��6%    62   �� $		 Age�4  .System.Windows.Controls.DataGridTemplateColumn  5Z      $ Edit Action��6)      CellTemplate 5[      �� 5\      .R�5]      �� $ btnEdit��6&   $
��Edit��68   ��6G   �� $	 DataContext.EditCommand� ��   �� AncestorType"  >���6�   �� 5^      5_      5a      5f      �� 5g   
   $��2��6   $��Right=�6"   $ 
Horizontal=�6?   .+�5k      �� $��Previous��6   $��95��6P   $��30��6[   ��6(   �� *PreviousPageCommand+6[   �� 5m      ��6   �� *CurrentPage+$ OneWay=��� 5n      ��6   �� *
TotalPages+$ OneWay=��� 5r      $
��Next��6   $��95��6H   $��30��6S   ��6$   �� *NextPageCommand+6S   5s      �� 5w   
   -   5        ! ��Name$! lblName��5w   U   $��3��68   $��0��6E   $��0 30 0 0q�6f   $��Center=�6y   $	��Top=�6�   $��62��6�   $��26��6�   " �� Target" 6   �� # �� ElementName$# txtName��.��5x      �� $ 
Horizontal=�6   .+�5y      �� $F��@http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_green.png��6   �� 5z      $��Name:��6   5{      5|      �� 5}   
   -   5        $! lblRoll��5}   X   $��4��68   $��0��6F   $��0 10 0 0q�6i   $��Center=�6|   $	��Top=�6�   $��62��6�   $��26��6�   " 6   �� $# txtRoll��.��5~      �� $ 
Horizontal=�6   .+�5      �� $F��@http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_green.png��6   �� 5�      $��Roll:��6   5�      5�      �� 5�   
   -   5        $! lbldateofbirth��5�   _   $��5��6?   $��0��6M   $��0 10 0 0q�6w   $��Center=�6�   $	��Top=�6�   $��62��6�   $��26��6�   " 6   �� $# txtdateofbirth��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $F��@http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_green.png��6   �� 5�      $��Dateofbirth:��6   5�      5�      �� 5�   
   -   5        $ txtName��5�      $��0 30 0 0q�6#   $��3��65   $��1��6B   $
��Left=�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6  $��18��6   ��6S   �� $	 CurrentStudent.Name�$ TwoWay=�$ PropertyChanged=�$ �� ValidatesOnDataErrors$ . 6   �� 5�   
   -   5        $ txtRoll��5�      $��4��6$   $��1��61   $��0 10 0 0q�6A   $
��Left=�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6  $��18��6   ��6S   �� $	 CurrentStudent.Roll�$ TwoWay=�$ PropertyChanged=�$ . 6   �� 5�   
   -	   5        $ txtdateofbirth��5�      $��5��6+   $��1��68   $��0 10 0 0q�6H   $
��Left=�6�   $
 Wrap=�6�   $	��Top=�6
  $	��120��6"  $��18��6.  ��6Z   �� $ 	 CurrentStudent.Dateofbirth�$ TwoWay=�$ PropertyChanged=�$ . 6.  �� 5�   
   $ 
Horizontal=�6   $��6��6.   $��1��6;   .+�5�      �� -
   5        $ btnSaveStudent��5�      $��6��6/   $��save student��6=   $
��Left=�6U   $��95��6s   $��20��6�   ��6~   �� $	 SaveCommand�6�   �� 5�      -   5        $ clrbtn��5�      $��6��6&   $��clear��63   $
��Left=�6i   $��95��6�   $��20��6�   ��6C   �� $	 ClearCommand�6�   �� 5�      -   5        $ updbtn��5�      $��Update��6&   $
��Left=�67   $	��Top=�6S   $��95��6l   $��20��6w   ��6�   �� $	 UpdateCommand��� 5�      -   5        $ dltbtn��5�      $��Delete��6'   $
��Left=�6_   $��95��6z   $��20��6�   ��68   �� $	 DeleteCommand�6�   5�      5�      5�      