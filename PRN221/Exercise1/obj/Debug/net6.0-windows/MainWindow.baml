   M S B A M L   `   `   `  ����D  @Exercise1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Exercise1	Exercise1  5   	       Exercise1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Exercise1     5   	     � Title$  
MainWindow��5   	   $	��467��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ tbStudentId��5
      $
��Left=�6'   $��
292,70,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $��HE123456��6j   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ tbStudentName��5      $
��Left=�6)   $��292,107,0,0q�6D   $
 Wrap=�6Y   $��Nguyen Van A��6m   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ tbEmail��5      $
��Left=�6#   $��292,144,0,0q�6>   $
 Wrap=�6S   $��anv123@abc.com��6g   $	��Top=�6}   $	��120��6�   G� 5   
   -   5         G�Name$ 
pwPassword��5      $
��Left=�6*   $��292,182,0,0q�6E   $	��Top=�6Z   $	��120��6r    G� Password$ abc123��6~   �� 5   
   -   5         ��Name$ cbMusic��5       d� 	IsChecked$
 TrueY�6$   $��Music��65   $
��Left=�6E   $��292,351,0,0q�6`   $	��Top=�6u   �� 5   
   -   5         ��Name$ major��5       �� SelectedIndex$ 0��6"   $
��Left=�64   $��292,310,0,0q�6O   $	��Top=�6d   $	��120��6|   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 	birthDate��5      
   SelectedDate
 
2002-11-126(   $
��Left=�6C   $��292,224,0,0q�6^   $	��Top=�6s   $	��120��6�   	� 5   
   -   5         	�Name$
 Male��5      $
 TrueY�6$   $
��Male��65   $
��Left=�6D   $��292,277,0,0q�6_   $	��Top=�6t   �� 5   
   -	   5         ��Name$ lbStudentId��5      $��	StudentId��6%   $
��Left=�69   $��
137,66,0,0q�6T   $	��Top=�6h   �� 5   
   -
   5        $ lbTitle��5      $��Information��6!   $
��Left=�67   $��
228,10,0,0q�6R   $	��Top=�6f   $	��367��6~   $��40��6�   $��22(�6�   $��Center=�6�   $
��Bold"�6�   �� 5   
   -   5        $ lbName_Copy��5      $��StudentName��6%   $
��Left=�6;   $��
137,99,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ lbEmail��5      $��Email��6!   $
��Left=�61   $��137,136,0,0q�6L   $	��Top=�6a   �� 5   
   -   5        $ lbBirthDate��5      $��	BirthDate��6%   $
��Left=�69   $��137,222,0,0q�6T   $	��Top=�6i   �� 5   
   -   5        $ 
lbPassword��5      $��Password��6$   $
��Left=�67   $��137,182,0,0q�6R   $	��Top=�6g   �� 5   
   -   5        $ lbGender��5      $��Gender��6"   $
��Left=�63   $��137,266,0,0q�6N   $	��Top=�6c   	� 5   
   -   5        $ Female��5      $��Female��6&   $��Center=�67   $��	0,277,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ lbMajor��5      $��Major��6!   $
��Left=�61   $��137,306,0,0q�6L   $	��Top=�6a   �� 5   
   -   5        $ 
cbFootball��5      $��Football��6'   $
��Left=�6:   $��400,351,0,0q�6U   $	��Top=�6j   �� 5   
   -   5        $ 	cbCooking��5      $��Cooking��6&   $
��Left=�68   $��510,351,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ cbBook��5      $
 TrueY�6#   $��Reading Book��64   $
��Left=�6K   $��624,351,0,0q�6f   $	��Top=�6{   �� 5   
   -   5        $ 	lbHobbies��5      $��Hobby��6#   $
��Left=�63   $��141,348,0,0q�6N   $	��Top=�6c   �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��Submit��6$   $
��Left=�65   $��318,385,0,0q�6P   $	��Top=�6e   $��25��6}   $��82��6�   6�   5#      5$      