   M S B A M L   `   `   `  ????P  LKMS_Altenburger_Andre, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:KMS_Altenburger_AndreKMS_Altenburger_Andre  5   	   -    'KMS_Altenburger_Andre.TransactionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:KMS_Altenburger_Andre     5   	   -   5          ? Title$  TransactionWindow??5   	   $	??457??5	   	   $	??684??5
   	    ? 
ResizeMode$ NoResize=?5   	   .??5      ? $??0,0,0,-6q?6   .+?5   
   ?? -   5         ??Name$ accountBalance_lbl??5      $??Account Balance:??5      $??461,132,0,0q?5      $
??Left=?5      $	??111??5      $??25??5      $	??Top=?5      ?? 5   
   -   5        $ showAccountBalance_lbl??5      $?? ??5      $??572,132,0,0q?5      $
??Left=?5      $	??102??5      $??25??5      $	??Top=?5      ?? 5    
   -   5        $ recievedMoney_lbl??5       $??Recieved Money:??5!      $??
461,74,0,0q?5"      $
??Left=?5#      $	??111??5$      $??29??5%      $	??Top=?5&      ?? 5(   
   -   5        $ showRecievedMoney_lbl??5(      $?? ??5)      $??
572,74,0,0q?5*      $
??Left=?5+      $	??102??5,      $??29??5-      $	??Top=?5.      ?? 50   
   -   5        $ sendMoney_lbl??50      $??Send Money:??51      $??461,102,0,0q?52      $??30??53      $	??Top=?54      $
??Left=?55      $	??111??56      ?? 58   
   -   5        $ showSendMoney_lbl??58      $?? ??59      $??572,100,0,0q?5:      $
??Left=?5;      $	??102??5<      $??32??5=      $	??Top=?5>      ?? 5@   
   -   5         ??Name$ recievingIbans_ListView??5@      $??0,36,247,251q?5A       ?? View 5C      ?? 5D      .P?5E      ?? $??RecievingIBAN??6%   -	   5        Recievingiban?? ?? Width$	 100??5G   %    ?? DisplayMemberBinding 5H   %   ?? *Recievingiban1+?? 5J      $??TransmitterIBAN??6%   $	 100??5K   %    5L   %   ?? *Transmitteriban1+?? 5N      $??Purpose??6%   $ 50??5O   %    5P   %   ?? *
Purpose1+?? 5R      $??Amount??6%   $ 50??5S   %    5T   %   ?? *	Amount1+?? 5V      $??BookingDate??6%   $ 90??5W   %    5X   %   ?? *Bookingdate1+5Z      5\      ?? 5^   
   -
   5         ??Name$ 
export_Btn??5^      $??Export??5_      $??496,304,0,0q?5`      $??43??5b      $	??Top=?5c      $
??Left=?5d      $??96??5e      ?? 5g   
   -   5        $ transmitterIbans_ListView??5g      $??0,226,247,22q?5h       5j      ?? 5k      .P?5l      ?? $??TransmitterIBAN??6%   -   5        Transmitteriban??$	 100??5n   %    5o   %   ?? *Transmitteriban1+?? 5q      $??RecievingIBAN??6%   $	 100??5r   %    5s   %   ?? *Recievingiban1+?? 5u      $??Purpose??6%   $ 50??5v   %    5w   %   ?? *
Purpose1+?? 5y      $??Amount??6%   $ 50??5z   %    5{   %   ?? *	Amount1+?? 5}      $??BookingDate??6%   $ 90??5~   %    5   %   ?? *Bookingdate1+5?      5?      ?? 5?   
   $??
Send Money??6   $??10,196,566,191q?5?      ?? 5?   
   $??Recieved Money??6   $??10,6,545,381q?5?      5?      5?      