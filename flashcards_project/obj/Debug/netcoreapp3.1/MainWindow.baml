   M S B A M L   `   `   `  ����L  Hproject_interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:project_interfaceproject_interface  5   	   "    project_interface.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:project_interface     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   
������� � 	Resources 5
       �� 
TargetType �� Property �� Value��%\  '��       '�� N     '�� �     �� 5   
   " ��6   .�5      ��  � �� �#545C526+   5      �� 5   
   " ��6   .�5      ��  � �� �#545C526+   �� 5       � �� �#98E2C66+   5      �� 5   
   " ��6   .�5      ��  � �� �#545C526+   �� 5       � �� �#BFEDEF6+   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5       $��* �6   .+�5"   
   �� .+�5#      �� $��30(�6   $
��Bold"�6&   $��Center=�68   Decks6\   �� 5$      -   5         ��Name$ listboxDecks��5$      5&      5'      �� 5)   
   $��1��6   .+�5*      �� $��Center=�6   $
��Bold"�65   Deck Options6U   �� 5+      -   5         ��Name$ btnStartDeck��5+      $��10, 25, 10, 0q�6+   .��6]   Start6d   �� 5,      -   5        $ 
btnAddDeck��5,      $��10, 25, 10, 0q�6)   .��6Y   
Add Deck6c   �� 5-      -   5        $ btnRenameDeck��5-      $��10, 25, 10, 0q�6,   .��6_   Rename6g   �� 5.      -   5        $ btnRemoveDeck��5.      $��10, 25, 10, 0q�6,   .��6_   Remove6g   5/      �� 51   
   $��2��6   .+�52      �� $��30(�6   $
��Bold"�6&   $��Center=�68   Cards6\   �� 53      -   5        $ listboxCards��53      55      56      �� 58   
   $��3��6   .+�59      �� $��Center=�6   $
��Bold"�65   Card Options6U   �� 5:      -   5        $ btnModifyCard��5:      $��10, 25, 10, 0q�6,   .��6_   Modify6g   �� 5;      -   5        $ btnRemoveCard��5;      $��10, 25, 10, 0q�6,   .��6_   Remove6g   �� 5<      -	   5        $ 
btnAddCard��5<      $��10, 25, 10, 0q�6)   .��6Y   
Add Card6c   5=      �� 5>   
   -
   5        $ btnSaveExit��5>      $	��100��6&   $��25��62   $��3��6>   $��Bottom=�6N   $��10q�6i   .��6�   Exit6�   5?      5@      