   M S B A M L   `   `   `  ����A  =TestPT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TestPTTestPT  5   	       TestPT.PLCAutoControl   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35b ^DevExpress.Xpf.Core.v18.2, Version=18.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.1, Version=21.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:TestPT     5   	     � Title$  PLCAutoControl��5   	   $	��300��6    $	��500��6-    � 	Resources 5
        TestPT.MainWindowsModel 	  model��%   &	          5   
   6!   5      .��5      � $��0,0,-6,0q�6A    � DataContext 6   ��  �� Source# [  ��5   
   �� 5       �� 
StartPoint$	 0 0&�6"    �� EndPoint$	 4 4&�63   .��5      �  � Offset$	 0.0Q�6    � Color$ #0b103f��6,   � 5      $	 1.0Q�6   $ #112837��6,   � 5      $	 2.0Q�6   $ #2d1952��6,   � 5      $	 0.3Q�6   $ #031623��6,   � 5      $	 4.0Q�6   $ #003754��6,   � 5      $	 0.1Q�6   $ #18213d��6,   � 5      $	 3.4Q�6   $ #524576��6,   � 5      $	 3.0Q�6   $ #07004d��6,   � 5      $	 0.2Q�6   $ #060230��6,   5      .+�5   
   �� -   5         ��Name$ TBNum��5      $
��Left=�6!   $��29��6<   $��
298,68,0,0q�6H   	 �� TextWrapping$
	 Wrap=�5      $�� ��6!   $	��Top=�6)   $��80��6A   
 J� RenderTransformOrigin$
 0.477,0.621&�6L   $��15(�6p    �� TextAlignment$ Center=�6~   �� 5   
   -   5        $ TBvalue��5      $
��Left=�6#   $��29��6>   $��278,102,0,0q�6J   $
	 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   $
 0.477,0.621&�6�   $��15(�6�   $ Center=�6�   d� 5   
   -   5         d�Name$ Sendbtn��5      $
��Send��6(   $
��Left=�67   $��29��6R   $��298,155,0,0q�6^   $	��Top=�6s   $��71��6�   {�6�   �� *	IsChecked+6�      TestPT.Tank  5    
   $
��Left=�6   $	��217��60   $��	59,25,0,0q�6=   $	��Top=�6P   $	��177��6h   5!      5"      