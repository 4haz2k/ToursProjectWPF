   M S B A M L   `   `   `  ����J  FWPFToursProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFToursProjectWPFToursProject  5           WPFToursProject.HotelsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPFToursProject     5      -   5          N� Title$  
HotelsPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��31* �6   6+   �� 5      $
��324* �6   �� 5      $	��95* �6   6+   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Center=�6   $��	10 0 10 0q�67   $��Кол-во строк��6J   6`   �� 5      -   5         ��Name$ PaginationComboBox��5       �� DisplayMemberPath$ Value��67   $��20��6Q   $	��200��6]    �� SelectedIndex$ 0��6i   6�   5      �� 5      $��30 0 0 0q�6   $ 
Horizontal=�6+   $��Center=�6D   .+�5      �� $��0 0 10 0q�6   $��Страницы��6.   6@   �� 5      -   5         ��Name$ 
PagesCount��5      $�� ��60   6:   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridHotels��5       $��1��6      AutoGenerateColumns .  	   
IsReadOnly	 . $��1��6c   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Название отеля��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Name+6b     5      $% Количество звезд��6%   $	 159 6`    6?   �� *CountOfStars+6n     5      $ Страна��6%   $	 259 6V    65   �� *Country.Name+6d     5       -   5        	TourCount��$ Кол-во туров��5    8    6N   �� *
Tour.Count+6o   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $
 auto 6)      CellTemplate 5"      �� 5#      .R�5$      �� $��BtnEdit��6=   -   5        $ ��Редактировать��5$   %   6d   5%      5'        5(      $
 auto 6)    5)      �� 5*      .R�5+      �� $��	BtnDelete��6<   -   5        $��X��5+   %   $��30��61   ��5,   "   �� 5-   &    �� 
TargetType" ��6,   .�5.   *   ��  �� Property � {� �� Value .  6F    �� Triggers 5/   *   �� 50   .    �� Binding 6:   �� *
Tour.Count+ �� Value 06Y   .a�51   2   ��  � {� . 6N   �� 52   2    � �� �#fac7166a   53   /   55   '   57      58      5:      5<      �� 5=   
   -   5        $��BtnAdd��5=   N   $��Добавить��6   $��2��6$   $��Center=�61   $
��Auto��6q   $��312,22q�6   $	��176��6�   6�   �� 5>   
   $ Vertical=�6   $��2��6,   $
��Left=�69   $	��185��6T   $��Center=�6`   .+�5?      �� -	   5        $��BtnPrev��5?   3   $+��%Предыдущая страница��6   6Z   �� 5@      -
   5        $��BtnFirst��5@   /   $#��Первая страница��6   6X   5A      �� 5B   
   $ Vertical=�6   $��2��6,   $��Right=�69   $	��185��6U   $��Center=�6a   .+�5C      �� -   5        $��BtnNext��5C   N   $)��#Следующая страница��6   $��Right=�62   6u   �� 5D      -   5         ��Name$ BtnLast��5D   N   $)��#Последняя страница��6   $��Right=�62   6_   5E      5F      5G      