   M S B A M L   `   `   `  ����J  FWPFToursProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFToursProjectWPFToursProject  5          WPFToursProject.ToursPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPFToursProject     5        N� Title$  	ToursPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��29* �6   �� 5      $��5* �6   .+�5   
   �� $��Stretch=�6   .+�5      �� ���#bae3e8$��0 5 0 5q�6.   .+�5      �� -   5         ��Name$ 
TotalPrice��5       �� Padding$ 0 0 10 0q�60   $��Right=�6C   $��20(�6_   $
��auto��6m    �� TextAlignment$ Right=�6z   6�   5      �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $:��4Введите название для поиска:��6   $	��175��6@   $ Right=�6L   $��5q�6b   6o   �� 5      -   5        $��
TBoxSearch��5   &   $	��225��6   $��5q�6]   6j   5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��Выберите тип:��6   $	��175��61   $ Right=�6=   $��5q�6S   6`   �� 5      -   5        $��	ComboType��5   '   $	��225��6    �� DisplayMemberPath$
 Name��6f   $��5q�6    �� SelectedIndex$ 0��6�   6�   5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $
��Bold"�6   �� 6/   $)�#Сортировка цены по:��63   6Q   	� 5      -   5         	�Name$ RadioButtonASC��5      $��5q�66   	 	� 	GroupName$	 Sorting��6A   $��Возрастанию��6w   	� 5       -   5        $ RadioButtonDESC��5       $��5q�67   $	 Sorting��6B   $��Убыванию��6y   5!      �� 5"      -   5        
 ��Name$
 CheckActual��5"      $E��?Показывать только актуальные туры��6j   $��Center=�6�   $��Center=�6�   6�   5#      �� 5%   
   -   5        $��
LViewTours��5%       $��1��6   $��Disabled=�62   $��Center=�6h   $��2��6�   ��5&      �� 5'      .R�5(      �  � Orientation$ 
Horizontal=�6    $��Center=�69   6X   5)      ��5+      �� 5,      .R�5-      � $��20q�6   $	��350��6'    5.      �� 5/      $��70 �6,   6:   �� 50      $	��310 �6,   6;   �� 51      $
��auto �6,   6<   �� 52      $
��auto �6,   6<   .+�54      �� $	��400��6    $��1��6,   $��UniformToFill=�69   $��Center=�6Q   $��5q�6n   ��55      �� 56   "    �� Path$ ImagePreview�6*    �� TargetNullValue 57   &   ��58   *   Resources\picture.png��5:   +   5<   #   5>      �� 5?      $��Center=�6:   $ Center=�6U   $	��5 5q�6l   $	��200��6y   $
��Wrap=�5@       $��Center=�64   $��20(�6Q   $
��Bold"�6_   ��5?   $   �� *Name+5A      �� 5B      $��2��6V   $��5 5 5 15q�6c   $��Center=�6u   $��20(�6�   $
��Bold"�6�   ��6$   �� *Price+ �� StringFormat$ {0:N2} РУБ��6�   �� 5C      $��3��6g   $��14(�6t   $��Right=�6�   ��6$   �� *TicketCount+$* $Билетов осталось: {0}��6�   �� 5D      $��4��6@   $��14(�6M   $
��Left=�6[   ��6$   �� *
ActualText+��6v   �� *ActualTextColor+6�   5E      5F      5H      �� 5I   
   -   5        $��Hotels��5I      $��Список отелей��6   $��2��67   $��Center=�6D   $	��Top=�6a   $	��176��6�   6�   5J      5K      