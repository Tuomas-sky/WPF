   M S B A M L   `   `   `  ����c  _framework_04_DependencyProperty_CallBack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:framework_04_DependencyProperty_CallBack(framework_04_DependencyProperty_CallBack  5   	   u?clr-namespace:framework_04_DependencyProperty_CallBack.Controls1framework_04_DependencyProperty_CallBack.Controls  5   	   9    3framework_04_DependencyProperty_CallBack.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:framework_04_DependencyProperty_CallBack     5   	   Tcontrols?clr-namespace:framework_04_DependencyProperty_CallBack.Controls     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $��45 �6   .+�5   
   C   =framework_04_DependencyProperty_CallBack.Controls.TrayControl  -   5          Name$
 tray��5      
�������$��5q�5         Size 5      ��  �� ElementName$ 
sliderSize�� �� Path$ Value�   Count 5      �� $ sliderCount��$ Value��� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� .+�5      �� $ 
Horizontal=�6   .+�5      �� $��托盘尺寸��6    $��3q�6,   $��Center=�67   �� 5      -   5         ��Name$ 
sliderSize��5      $	��200��62   	 � Value$	 30Q�6>   
 � Maximum$	
 100Q�5      $��Center=�6+   5      �� 5      $��5��6   �� 5      $ 
Horizontal=�6   .+�5      �� $��托盘数量��6    $��3q�6,   $��Center=�67   �� 5      -   5        $ sliderCount��5      $	��200��63   $	 0Q�6?   $
 28Q�5       $��Center=�6*   5!      5"      �� 5#      $��当前装配数量：��6   $��3q�6'   $��Center=�62   �� 5$      �6   �� $
 tray��$ SelectedCount� �� 5%      $�总数量：��6    �� 5&      �6   �� $
 tray��$ Count�5'      �� 5(      -   5        $��提交��5(      $��50��6"   $��25��6-   69   5)      5*      5+      