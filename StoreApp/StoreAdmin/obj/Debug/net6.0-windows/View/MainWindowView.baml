   M S B A M L   `   `   `  ����E  AStoreAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StoreAdmin.ViewStoreAdmin.View  5   	   ;"clr-namespace:StoreAdmin.ViewModelStoreAdmin.ViewModel  5   	   $    StoreAdmin.View.MainWindowView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:StoreAdmin.View  5   	   2	ViewModel"clr-namespace:StoreAdmin.ViewModel  5   	     � Title$  Admin Panel��5
   	   $	��650��5   	   $
��1200��5   	    � WindowStyle$
 None=�5   	   .��5      � -   5        $��	MainPanel��5       � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.3* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�5      $��Right=�5      .+�5      �� -   5        $��CloseButton��5      $��20��5!      $��20��5"      
������ $��10q�5$      .��5%      �� $��/Images/shutdown_mo.png��6   $
��Fill=�5&      5'      5)      �� 5+   
   $��1��6   ��5,      �� *CurrentViewModel+5.      �� 50   
   $��2��6   $
��Left=�51      $	��150��52      $	��100��53      $	��Add��54       "  MaterialDesignFlatDarkBgButton#��[  56      ��55      �� *
AddCommand+57      �� 59   
   $��2��6   $��Right=�5:      $	��150��5;      $	��100��5<      $��Delete��5=      #��[  5?      ��5>      �� *DeleteCommand+5A      �� 5C   
   $��3��6   $��1��6$   $��20(�5E      $��DemiBold"�5F      ��5D      �� *
Products+ �� View 5H      �� 5J       �� AllowsColumnReorder$
 true��6    �� ColumnHeaderToolTip$ DoInfo��66   .P�5K      �� $
��Name��6K    �� Width$	 130��6Y   	 �� DisplayMemberBinding	 6%   �� *Name+6Y   �� 5L      $��Price��6L   $	 250��6[   	 6%   �� *Price+6[   5M      5Q      5S      5T      