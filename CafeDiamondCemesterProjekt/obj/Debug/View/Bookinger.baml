   M S B A M L   `   `   `  ����U  QCafeDiamondCemesterProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:CafeDiamondCemesterProjekt.ViewModel$CafeDiamondCemesterProjekt.ViewModel  5      /    )CafeDiamondCemesterProjekt.View.Bookinger   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H	ViewModel2clr-namespace:CafeDiamondCemesterProjekt.ViewModel     5        N� Title$  Page1��5	      .��5
      �  � DataContext 5   
   ;  5CafeDiamondCemesterProjekt.ViewModel.ViewModelBooking  5      .+�5   
   &   System.Windows.Controls.Calendar  $
��Left=�6   $��
211,41,0,0q�6.   $	��Top=�6B   $	��159��6Z   $	��188��6g      SelectedDate 6s   �� *bookingViewDato+� 5   
   $
��Left=�6   $	��479��6*   $	��Top=�67   $	��206��6O   ���	#FF0A0301 J� Opacity$	 0.6Q�6r   $��5,6,0,0q�6�    5        5      .+�5      �� -   5        $
��Left=�5      $��
15,131,0,0q�60   $	��Top=�6D   $	��186��6\   $��34��6h   ���	#FF150101$��Tilføj Booking��6�   ��6�   �� *TilføjBooking+ �� Mode$ OneWay=��� 5      $��
Tjek Kunde��6   $
��Left=�6*   $��	15,38,0,0q�6E   $	��Top=�6X   $	��186��6p   $��33��6|   ��6�   �� *	TjekKunde+$ OneWay=��� 5      $
��Left=�6   $��23��61   $��	72,10,0,0q�6=    �� TextWrapping$
 Wrap=�6P   $	��Top=�6|   $	��129��6�   ��6d   �� *BMobil+6�   �� 5      $
��Left=�6   $��23��61   $��	72,76,0,0q�6=   $
 Wrap=�6P   $	��Top=�6{   $	��129��6�   ��6d   �� *Bbord+6�   (  "System.Windows.Controls.DatePicker  5      $
��Left=�6   $��
72,102,0,0q�64   $	��Top=�6H   $	��129��6`      Text 6l   �� *Bdato+$ OneWayToSource=��� 5      $��Mobil��6   $
��Left=�6$   $��10,7,0,0q�6?   $	��Top=�6Q   $��52��6i   
���   �
�������6�   �� 5      $
��Bord��6   $
��Left=�6#   $��	10,71,0,0q�6>   $	��Top=�6Q   $��52��6i   
���   �
�������6�   �� 5      $
��Dato��6   $
��Left=�6#   $��
10,100,0,0q�6>   $	��Top=�6R   $��52��6j   
���   �
�������6�   �� 5      $
��Left=�60   $��
15,170,0,0q�6K   $	��Top=�6_   $	��181��6w   
���   �
�������$	��190��6�   ��6   �� *	Bstatus+6�   5      �� 5   
   $��Slet Booking��6   $
��Left=�6(   $��
216,10,0,0q�6C   $	��Top=�6W   $	��178��6o   $��29��6{   ��6�   �� *SletBooking+$ OneWay=��� 5    
   $��Updater��6   $
��Left=�6#   $��216,205,0,0q�6>   $	��Top=�6S   $	��178��6k   $��29��6w   ��6�   �� *
FyldListen+$ OneWay=��� 5!   
   $
��Left=�6   $	��245��6.   $��216,239,0,0q�6;   $	��Top=�6P   $	��519��6h   {�.  ��6�   �� *BookingTilView+�� 5"   
   $
��Left=�6   $	��224��6.   $	��Top=�6;   $	��336��6S   $��
399,10,0,0q�6�   ��6_   �� *BookingTilView2+ �� SelectedValue 6�   �� *LView+5%      5&      