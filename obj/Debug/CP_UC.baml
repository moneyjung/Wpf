   M S B A M L   `   `   `  ����A  =TestPT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TestPTTestPT  5          TestPT.CP_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35b ^DevExpress.Xpf.Core.v18.2, Version=18.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.1, Version=21.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:TestPT     5        � 	Resources  5
         ProgressBarAnimation �� 
TargetName g� RepeatBehavior �� TargetProperty g� Duration )� PathGeometry �� KeyTime �� Value��%�  &	        �� 5   
   -   5        $	 arc��5      $ Forever��6G   .��5      )� $ Point�6&   $ 0:0:2D�6H    5      B� 5      $h��bM 0 -25 A 25 25 0 0 1 0 25                                                     A 25 25 0 0 1 0 -25C�6#   5      �� 5      $ 
IsLargeArc�6-   $ 0:0:2D�6T   .p�5      s� $ 0:0:0��6*    .  6:   s� 5      $ 0:0:1��6*    . 6:   5      5      5      .��5      � .+�5   
   �� .+�5       F� -   5         F�Name$ ProgressPath��5       
������ 
����� �$��10��5#      	 �� StrokeStartLineCap$
	 Flat=�5$      
 �� StrokeEndLineCap$

 Flat=�5%       �� StrokeLineJoin$ Round=�5&       J� RenderTransformOrigin$ 0.5 0.5&�5'      ��5*      B� 5+      .��5,      E� -   5        
pathFigure�� E� 
StartPoint$ 0 -25&�5,   9    E� IsClosed .  .��5-      ��  �� Point$ 0 -25&�6*   �� 5.      -   5        arc�� �� Size$ 25 25��5/   %    �� 
IsLargeArc .  �� SweepDirection$ 	Clockwise=�51      53      54       J� Effect 56      3  -System.Windows.Media.Effects.DropShadowEffect  57         
BlurRadius$ 50Q�6'      ShadowDepth$ 2Q�67      	Direction$	 -90Q�6G      Color$
 Aqua��58   '   5:      5;      5=      5>      