# UnixDirectoryFormatting
An application to convert MS-DOS format paths to unix format paths
------------------------------------------------------------------
R on windows uses a Unix (/) rather than a MS-DOS (\) slash which makes copying paths etc a problem.  
I have a quick and dirty solution that uses a simple dos program to do the conversion and then put the result on the clipboard.
The only minor annoyance with this approach is that it momentarily flashes a dos box up while the app executes but it seems a
small price to pay to avoid messing about with com and shell extensions.

To Use
Create a registry entry in 
[HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\Copy Path Unix Format]
and also in 
[HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\Copy Path Unix Format\Command]
@="%****PUT_PATH_HERE****%\\UnixDirectoryFormatting.exe \"%1\""


After this Your Registry tree  Will look like this
SOFTWARE
    |->Classes
          |->*
            |->shell
                |->Copy Path Unix Format
                  |-> Command
                  
and in command you will have a single key  (Default) of type REG_SZ with data ?:...\UnixDirectoryFormatting.exe "%1"

Now if you right click any file in windows explorer you will see the Copy Path Unix Format menu.

