   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5   	   g cMicrosoft.ReportViewer.WinForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms 5   	    TestProject   TestProject.ClockReport   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms     5   	   -   5          � Title$  ClockReport��5   	   $��565.823��6   $��579.747��6.    � UseLayoutRounding .   � 
ResizeMode$ NoResize=�6o    � ShowInTaskbar .   � WindowStyle$
 None=�6�   .��5      � ���	#FF5D5C5C.+�5   
   7   1System.Windows.Forms.Integration.WindowsFormsHost  -   5          Name$ winReportView��5      $��0,73,0,0q�62    K� ZIndex$ 1��6D      Child. 5	      /  )Microsoft.Reporting.WinForms.ReportViewer  -   5        repView��   ProcessingMode$ Local=�5	   /   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control	   Visible	 . 
   Enabled
 . 6U   5
      �� 5   
   -   5         ��Name$ btnSearchClocks��5      $��Generate Report��6*   $
��Left=�6D   $��
232,46,0,0q�6_   $	��Top=�6s   $	��107��6�   6�   �� 5   
   -   5         ��Name$ txtFromDate��5      $
��Left=�6'   $��23��6B   $��	93,10,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   .��6�   ��5      �� 5       �� Path$
 Date�6    �� StringFormat$ {0:MM/dd/yyyy}��6&   .��5      5      �� 5   
   -   5        $ 	txtToDate��5      $
��Left=�6%   $��23��6@   $��
388,10,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   .��6�   ��5      �� 5      $
 Date�6   $ {0:MM/dd/yyyy}��6&   .��5      5      �� 5   
   $��From:��6   $
��Left=�6    $	��Top=�6;   $��48,7,0,0q�6S   
�������6e   �� 5   
   $	��To:��6   $
��Left=�6   $	��Top=�69   $��	362,7,0,0q�6Q    J� RenderTransformOrigin$ 7.086,0.948&�6d   
�������6�   �� 5   
   -   5        $ btnClose��5      $��X��6#   $��	562,0,0,0q�6/   $	��Top=�6B   $
��Left=�6Z   $��18��6u   $��19��6�   6�   5      5      