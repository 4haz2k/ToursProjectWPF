   M S B A M L   `   `   `  ����J  FWPFToursProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFToursProjectWPFToursProject  5      !    WPFToursProject.AddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPFToursProject     5        N� Title$  AddEditPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��49* �6   �� 5      $
��111* �6   .+�5   
   �� $��Название��6   $��Center=�6$   $��Center=�6A   6^   �� 5   
   $%��Количество звёзд��6   $��1��6,   $��Center=�69   $��Center=�6V   6s   �� 5   
   $��Страна��6   $��2��6"   $��Center=�6/   $��Center=�6L   6i   �� 5   
   $��1��6(   $��30��68   $��5 5 5 5q�6D   ��6   �� *Name+6W   �� 5   
   $��1��60   $��1��6@   $��30��6M   $	��175��6Y   $
��Left=�6e   $��5 5 5 5q�6�   ��6   �� *CountOfStars+6�   �� 5   
   -   5         ��Name$ ComboCountries��5   v    �� DisplayMemberPath$
 Name��64   $��2��6M   $��2��6Z   $��30��6j   $��5 5 5 5q�6�    �� SelectedItem 6   �� *	Country+6�   �� 5   
   -   5        $��BtnSave��5   F   $��Сохранить��6   $��2��6%   $��3��69   6m   5      5      