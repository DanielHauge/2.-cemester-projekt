   M S B A M L   `   `   `  ����U  QCafeDiamondCemesterProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:CafeDiamondCemesterProjekt.ViewModel$CafeDiamondCemesterProjekt.ViewModel  5      /    )CafeDiamondCemesterProjekt.View.UserAdmin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H	ViewModel2clr-namespace:CafeDiamondCemesterProjekt.ViewModel     5        N� Title$  	UserAdmin��5      $��473.91��6   $��1030.537��6$    � DataContext 5
      4  .CafeDiamondCemesterProjekt.ViewModel.Viewmodel  5   
   .��5      � $��0,10,-540,-227q�6   .+�5   
   �� $��Rediger��6   $
��Left=�6#   $��410,403,0,0q�6>   $	��Top=�6S   $	��186��6k   $��21��6w   ��6�   �� *RedigerKunde+ �� Mode$ OneWay=��� 5   
   $
��Slet��6   $
��Left=�6    $��751,403,0,0q�6;   $	��Top=�6P   $	��104��6h   $��21��6t   ��6�   �� *	SletKunde+$ OneWay=��� 5   
   $��Søg Bruger :��6   $
��Left=�6'   $��
410,17,0,0q�6B   $	��Top=�6V   
���   �$��95��6�   $��28��6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��25��6-   $��
510,17,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��258��6y   ��6�   �� *	søgefelt+$ OneWayToSource=��� 5   
   $
��Søg��6   $
��Left=�6   $��
789,17,0,0q�6:   $	��Top=�6N   $��66��6f   $��25��6q   ��6}   �� *SøgFunktion+$ OneWay=��� 5   
   $��Tank Op��6   $
��Left=�6#   $��620,403,0,0q�6>   $	��Top=�6S   $	��109��6k   $��21��6w   ��6�   �� *TankOpRelay+$ OneWay=�� 5   
   $
��Left=�6   $	��401��6*   $��	26,23,0,0q�67   $	��Top=�6J   $	��358��6b   .+�5      �� $��Opret / Rediger��6   $
��Left=�6/   $��
86,266,0,0q�6J   $	��Top=�6^   $	��180��6v   ��6�   �� *TilføjBruger+$ OneWay=�� 5      $��0,10,-28,-27q�6   .+�5      �� $
��Left=�6   $��25��65   $��
52,159,0,0q�6A   $
 Wrap=�6U   $	��Top=�6�   $	��274��6�   ��6i   �� *Mobil+6�   �� 5      $
��Left=�6   $��26��65   $��
52,128,0,0q�6A   $
 Wrap=�6U   $	��Top=�6�   $	��274��6�   ��6i   �� *Email+6�   �� 5      $
��Left=�6   $��25��65   $��	52,98,0,0q�6A   $
 Wrap=�6T   $	��Top=�6~   $	��274��6�   ��6h   �� *navn+6�   �� 5      $
��Left=�6   $��25��65   $��
52,220,0,0q�6A   $
 Wrap=�6U   $	��Top=�6�   $	��274��6�   ��6i   �� *Saldo+6�   �� 5      -   5         ��Name$ KundeListeView1��5      $
��Left=�64   $	��313��6O   $��410,45,-444,0q�6\   $	��Top=�6s   $	��420��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6�   �� *ListeTilView+ �� SelectedValue 6�   �� *
ListView+�� 5      $
��Left=�63   $��
10,275,0,0q�6N   $	��Top=�6b   $��97��6z   $	��316��6�   ��6   �� *status+��6�   Z� �� 5      $
��Navn��6   $
��Left=�6'   $��4,97,0,0q�6B   $	��Top=�6T   $
��Bold"�6l   �� 5       $��Email��6   $
��Left=�6(   $��	4,129,0,0q�6C   $	��Top=�6V   $
��Bold"�6n   �� 5!      $��Saldo��6   $
��Left=�6(   $��	3,215,0,0q�6C   $	��Top=�6V   $
��Bold"�6n   �� 5"      $��Mobil��6   $
��Left=�6(   $��	4,158,0,0q�6C   $	��Top=�6V   $
��Bold"�6n   �� 5#      $
��Kode��6   $
��Left=�6'   $��	4,189,0,0q�6B   $	��Top=�6U   $��38��6m   $
��Bold"�6x   �� 5$      $
��Left=�6   $��25��65   $��
52,189,0,0q�6A   $
 Wrap=�6U   $	��Top=�6�   $	��274��6�   ��6i   �� *
password+6�   �� 5%      $��Opret bruger��6   $
��Left=�6/   $��4,66,0,0q�6J   $	��Top=�6\   $��97��6t   $
��Bold"�6   5&      �� 5'      -   5        $ KundeListeView��5'      $
��Left=�6/   $	��332��6J   $��386,38,-473,0q�6W   $	��Top=�6n   $	��445��6�   $
 TrueY�6�    6�   �� *
ListView+��6�   �� *ListeTilView+5)      5*      5+      