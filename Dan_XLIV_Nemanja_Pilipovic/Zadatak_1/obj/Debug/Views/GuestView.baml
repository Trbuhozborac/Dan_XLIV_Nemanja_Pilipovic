   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	       Zadatak_1.Views.GuestView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Make your Order��5   	   $	��450��6!   $	��300��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5!   
   � $��1��6   $��1��6   $
��auto��6,   $
��auto��6:   .+�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ AllFood��5"         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5#   )   $��0,10,0,0q�6D   ��5"   (   �� *	AllFood+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5#   V   �� *Food+$ PropertyChanged=�	   Columns	 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Food��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+  5&      $
 Price��6)    68   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  5'         CellTemplate 5(      �� 5)      .R�5*   "   �� $��
btnAddItem��6)   $��+��6;   $��4q�5-   %   $
��Bold"�60   ��5+   %   �� *DataContext.AddItem+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �5-   0   5.      50      52      53      �� 55   
   $��1��6   $��2��6$   $��Price:��61   $��0,10,0,0q�6?   �� 56   
   $��1��6   $��3��6"   ��6/   �� *Price+$ PropertyChanged=��� 58   
   -   5        $��btnSave��58   .   $��1��6   $��4��6!   $��	Add Order��6=   $��20��6Q   $	��100��6]   $
��Left=�6i   $��0,10,0,0q�59   O   ��6   �� *Save+$ PropertyChanged=�6O   �� 5<   
   -   5        $��btnClose��5<   .   $��2��6   $��4��6!   $��Close��6>   $��20��6N   $	��100��6Z   $��Right=�6f   $��0,10,0,0q�5=   P   ��6   �� *Close+$ PropertyChanged=�6P   5>      5?      