   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoListToDoList  5   	       ToDoList.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ToDoList     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��500��6)   $	��600��65   $	��500��6E    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5
      �  � RowDefinitions 5   
   �� 5      $
��0.8* �6   �� 5      $
��0.2* �6   .+�5   
   �� -   5         ��Name$ MainListView��5      $��0��6)   ��66   �� *DoList+ �� View 5      �� 5       �� AllowsColumnReorder$
 true��6    �� ColumnHeaderToolTip$ DoInfo��66   .P�5      �� $
��Name��6K    �� Width$	 120��6Y   	 �� DisplayMemberBinding	 6%   �� *Name+6Y   �� 5      $	 250��6R   	 6%   �� *Description+.��5      �� $��Description��6/   
 � ContextMenu
 5      �� 5   "   -   5         ��Name$ DescriptionContextMenu��5   /   .@�5   &   m� $��	Ascending��6/   m� 5   &   $��
Descending��6/   5   #   5      5      �� 5      $
��Type��6K   $	 130��6Y   	 6%   �� *Type+6Y   5      5!      ]� 5#   
   $��1��6   
�������$��False��65   .+�5$      �� -   5         ��Name$ 	AddButton��5$      $
��Left=�6@   $��20q�6V   $��50��6b   $	��100��6n   $	��Add��6z   $��18(�6�   $��DemiBold"�6�   
�������
�����p�6�   �� 5%      -   5        $ RemoveButton��5%      $��Right=�6F   $��20q�6]   $��50��6i   $	��100��6u   $��Remove��6�   $��18(�6�   $��DemiBold"�6�   
�������
�����p�6�   5&      5(      5)      