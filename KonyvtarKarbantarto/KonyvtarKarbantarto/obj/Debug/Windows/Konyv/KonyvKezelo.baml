   M S B A M L   `   `   `  ����N  JKonyvtarKarbantarto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:KonyvtarKarbantarto.WindowsKonyvtarKarbantarto.Windows  5   	   -    'KonyvtarKarbantarto.Windows.KonyvKezelo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:KonyvtarKarbantarto.Windows     5   	     � Title$  KonyvKezelo��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��5* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Griddo��5   %      
IsReadOnly . �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ GetDataKonyvek��5      $��Frissít��6-   $��1��6\   $��30��6l   $	��150��6x   $	��Top=�6�   $��10 10 10 10q�6�   �� 5      -   5        $ 
CreateBook��5      $��30��6B   $	��150��6N   $	��Top=�6Z   $��Könyv hozzáadása��6r   �� 5      -   5        $ EditBook��5      $��
Változtat��6>   $	��Top=�6R   $	��150��6j   $��30��6v   $��
10 10 10 0q�6�   �� 5      -   5        $ Delete��5      $��Törlés��6%   $	��150��66   $��30��6B   $	��Top=�6N   $��10 10 10 10q�6f   6{   5      �� 5   
   -   5        $
 Back��5   .   $��1��6   $��1��6!   $��Vissza��6O   $��30��6`   $	��150��6l   5      5      