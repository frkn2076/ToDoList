   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoListToDoList  5          ToDoList.ToDoLists   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ToDoList     5        N� Title$  	ToDoLists��5	      .��5      � ��5   
   �� 5       �� ImageSource$ background/back.png��6    � ColumnDefinitions 5   
   �� 5      $
��401* �6   �� 5      $
��399* �6   .+�5   
   �� -   5        $
��Back��5      $
��Left=�6    $��	30,10,0,0q�6;   $	��Top=�6N   $��36��6f   $��70��6r   
�������
������ 6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ToDoListGrid��5         AutoGenerateColumns$ False��6'   $	��300��6C   $��0,65,0,0q�6P   $	��Top=�6b   $��2��6z      CanUserAddRows$ False��6�   
������    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   MinWidth$ 50Q�6%      Header$ Id��63      
IsReadOnly$
 True��6V   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� *Id+6V     5      $	 150Q�6%   $
 Name��64   $
 True��6[   	 6B   �� *Name+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ View/Add Item��6)   
   CellTemplate
 5      �� 5      .R�5      �� $��btnView��6%   -   5        $��View/Add Item��5   4   6L   5      5        5      $ Delete��6)   
 5       �� 5!      .R�5"      �� $��	btnDelete��6%   -   5        $��Delete��5"   6   6G   5#      5%      5'      �� 5(   
   -   5        $��NameToInsert��5(      $��Center=�6&   $��Center=�6I   $��
55,365,0,0q�6n   $�� ��6�    �� TextWrapping$
 Wrap=�6�   $
��Left=�6�   $��90��6�   $��30��6�   $	��Top=�6�    �� 	MaxLength$ 20��6�   �� 5)   
   -   5        $��Add ToDoList��5)      $
��Left=�6(   $��200,365,0,12q�6C   $	��Top=�6Y   $��30��6q   $��80��6}   
�������
������ 6�   5*      5+      