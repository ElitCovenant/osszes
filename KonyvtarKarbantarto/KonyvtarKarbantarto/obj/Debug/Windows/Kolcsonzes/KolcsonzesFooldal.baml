   M S B A M L   `   `   `  ����N  JKonyvtarKarbantarto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:KonyvtarKarbantarto.Windows.Kolcsonzes&KonyvtarKarbantarto.Windows.Kolcsonzes  5   	   >    8KonyvtarKarbantarto.Windows.Kolcsonzes.KolcsonzesFooldal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:KonyvtarKarbantarto.Windows.Kolcsonzes     5   	     � Title$  KolcsonzesFooldal��5   	   $	��450��6#   $	��800��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��5* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Griddo��5   %      
IsReadOnly . �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ GetDataLoan��5      $��Frissít��6*   $��1��6V   $��30��6f   $	��150��6r   $	��Top=�6~   $��10 10 10 10q�6�   �� 5      -   5        $ 
CreateLoan��5      $��30��6B   $	��150��6N   $	��Top=�6Z   $ ��Kölcsönzés hozzáadása��6r   �� 5      -   5        $ EditLoan��5      $��
Változtat��6>   $	��Top=�6R   $	��150��6j   $��30��6v   $��
10 10 10 0q�6�   �� 5      -   5        $ Returned��5      $��
Befejezés��6'   $	��150��6;   $��30��6G   $	��Top=�6S   $��10 10 10 10q�6k   6�   5      �� 5   
   -   5        $
 Back��5   .   $��1��6   $��1��6!   $��Vissza��6O   $��30��6`   $	��150��6l   5      5      