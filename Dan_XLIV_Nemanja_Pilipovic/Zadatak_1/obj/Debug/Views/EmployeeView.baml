   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   "    Zadatak_1.Views.EmployeeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  EmployeeView��5   	   $	��450��6   $	��900��6+   .��5	      �  � ColumnDefinitions 5
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
��auto��6:   .+�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ 	AllOrders��5"         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5#   )   $��0,10,0,0q�6D   ��5"   *   �� *	AllOrders+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5#   V   �� *Order+$ PropertyChanged=�	   Columns	 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Price��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Price+  5&      $
 
Order Date��6)    6=   �� *CreatedDate+  5'      $
 Orderr Time��6)    6>   �� *CreatedTime+  5(      $
 State��6)    68   �� *State+4  .System.Windows.Controls.DataGridTemplateColumn  5*         CellTemplate 5+      �� 5,      .R�5-   "   �� $��btnAllow��6)   $��Accept Order��69   $��4q�50   %   $
��Bold"�60   ��5.   %   �� *DataContext.AllowOrder+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �50   0   51      53        54       55      �� 56      .R�57   "   �� $��btnDeclineOrder��6)   $��Decline Order��6@   $��4q�5:   %   $
��Bold"�60   ��58   %   �� *DataContext.DeclineOrder+$ PropertyChanged=� �� *FindAncestor+" �5:   0   5;      5=        5>       5?      �� 5@      .R�5A   "   �� $��btnSaveOrder��6)   $��
Save Order��6=   $��4q�5D   %   $
��Bold"�60   ��5B   %   �� *DataContext.SaveOrder+$ PropertyChanged=� �� *FindAncestor+" �5D   0   5E      5G        5H       5I      �� 5J      .R�5K   "   �� $��btnDeleteOrder��6)   $��Delete Order��6?   $��4q�5N   %   $
��Bold"�60   ��5L   %   �� *DataContext.DeleteOrder+$ PropertyChanged=� �� *FindAncestor+" �5N   0   5O      5Q        5R       5S      �� 5T      .R�5U   "   �� $��btnSeeGuest��6)   $��Order Owner��6<   $��4q�5X   %   $
��Bold"�60   ��5V   %   �� *DataContext.OrderOwner+$ PropertyChanged=� �� *FindAncestor+" �5X   0   5Y      5[      5]      5^      �� 5_   
   -   5        $��btnClose��5_   .   $��1��6   $��2��6!   $��Close��6>   $��20��6N   $	��100��6Z   $��Right=�6f   $��0,10,0,0q�5`   P   ��6   �� *Close+$ PropertyChanged=�6P   5a      5b      