   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoListToDoList  5          ToDoList.Items   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ToDoList     5        N� Title$  Items��5	      .��5
      � ��5   
   �� 5       �� ImageSource$ background/back.png��6   .+�5   
   �� -   5        $
��Back��5      $
��Left=�6    $��	30,10,0,0q�6;   $	��Top=�6N   $��36��6f   $��70��6r   
�������
������ 6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	ItemsGrid��5         AutoGenerateColumns$ False��6$   $	��300��6k   $��0,65,0,0q�6x   $	��Top=�6�      CanUserAddRows$ False��6�   
������    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   MinWidth$	 100Q�6%      Header$
 Name��64      
IsReadOnly$
 True��6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name+6[     5      $	 150Q�6%   $ Description��64   $
 True��6i    6I   �� *Description+6i     5      $	 100Q�6%   $ DeadLine��64   $
 True��6c    6F   �� *
DeadLine+6c   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 50Q�6)   $ Complete��67   $ False��6u    6I   �� *
Complete+	 �� Mode$	 TwoWay=�6u     5      $	 100Q�6%   $ 
CreateDate��64   $
 True��6g    6H   �� *
CreateDate+6g   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Delete��6)   
   CellTemplate
 5      �� 5      .R�5      �� $��Delete��6%   -   5        $��Delete��5   3   6D   5      5      5      �� 5   
   -   5        $��NameToInsert��5      $��Center=�6&   $��Center=�6I   $��	7,365,0,0q�6n   $�� ��6�    �� TextWrapping$
 Wrap=�6�   $
��Left=�6�   $	��100��6�   $��30��6�   $	��Top=�6�   �� 5    
   -   5        $��DescriptionToInsert��5       $��Center=�6-   $��Center=�6P   $��107,365,0,0q�6u   $�� ��6�   $
 Wrap=�6�   $
��Left=�6�   $	��150��6�   $��30��6�   $	��Top=�6�   �� 5!   
   -   5        $��Add Item��5!      $
��Left=�6$   $��400,365,0,12q�6?   $	��Top=�6U   $��30��6m   $��50��6y   
�������
������ 6�   (  "System.Windows.Controls.DatePicker  5"   
   -   5        $��DeadLineToInsert��5"      $
��Left=�6-   $��270,368,0,0q�6H   $	��Top=�6]   
������ 6u     5#   
   -   5        $��ToDatePicker��5#      $
��Left=�6)   $��
560,16,0,0q�6D   $	��Top=�6X   
������ 6p     5$   
   -	   5        $��FromDatePicker��5$      $
��Left=�6+   $��
420,16,0,0q�6F   $	��Top=�6Z   
������ 6r   �� 5%   
   -
   5        $��IsExpiredCheckBox��5%      $��	IsExpired��6,   $
��Left=�6@   $��
280,20,0,0q�6[   $	��Top=�6o   �� 5&   
   -   5        $��IsCompletedCheckBox��5&      $��IsCompleted��6.   $
��Left=�6D   $��
180,20,0,0q�6_   $	��Top=�6s   �� 5'   
   $��From:��6   $
��Left=�6    $��
370,16,0,0q�6;   $	��Top=�6O   �� 5(   
   $	��To:��6   $
��Left=�6   $��
530,16,0,0q�69   $	��Top=�6M   �� 5)   
   -   5        $��Filter��5)      $
��Left=�6"   $��
655,10,0,0q�6=   $	��Top=�6Q   $��36��6i   $��50��6u   
�������
������ 6�   �� 5*   
   -   5        $��Remove Filter��5*      $
��Left=�6)   $��
720,10,0,0q�6D   $	��Top=�6X   $��36��6p   $��50��6|   
�������
������ 6�   �� 5+   
   -   5        $��Order��5+      $
��Left=�6    $��
108,25,0,0q�6;   $	��Top=�6O   $��65��6g   $��20��6r   .@�5,      �� .��6   
CreateDate6'   �� 5-      .��6   
DeadLine6%   �� 5.      .��6   Name6!   �� 5/      .��6   
Complete6%   50      �� 51   
   $��Order��6   $��Center=�6    $��Center=�6C   $
��Left=�6h   $��	108,0,0,0q�6�   $	��Top=�6�   $��25��6�   $��65��6�   52      53      