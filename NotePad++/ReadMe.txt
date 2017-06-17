-----------------------------------------------------------All Version------------------------------------------------------------------------------
References: https://github.com/jacobslusser/ScintillaNET, https://www.codeproject.com/articles/161871/fast-colored-textbox-for-syntax-highlighting
and a bunch of searching (https://stackoverflow.com/ https://docs.microsoft.com/en-us/dotnet/articles/csharp/csharp or https://www.codeproject.com/)

Note that this project used visual studio 2017, so you might be have some troubles about properties (since the 2017 version used a different auto generated property) 
I will fix it later
----------------------------------------------------------------------------------------------------------------------------------------------------
Version 1.0:
The first version took the advantage of scintilla. But my lecturer didn't allow use it, we had to do everything by ourselves (>_<)
if you wish, You can still check out this version in file: NotePad++Scintilla 

----------------------------------------------------------------------------------------------------------------------------------------------------
Version 1.1:
File: save, save as, open, new, close, close all (references and customized)

Edit: cut, copy, paste, select all, clear, UpperCase, LowerCase (references and customized)

View: zoom in, zoom out, zoom 100% (references)

Basic automatic syntax highlight (at least two weeks to figure out, references, customized)

Basic automatic line numbering (at least half of week to figure out, references, customized)

Basic bookmark (at least two or three days to figure out, from the idea of linenumbering)

Basic Document Map (at least half of week to figure out, no references)

Basic Autocomplete (just one days to figure out, references)

Language: NormalText, C, C++, C#, VB.NET (keywords from home page of microsoft)

Drag and drop file (references)

Drag and drop tab page (references)

"x" button on each tab page and close tab page by "x" button (references)

----------------------------------------------------------------------------------------------------------------------------------------------------
Version 1.2:
Store tab page status
Basic Undo And Redo (One week to figure out, no references)

----------------------------------------------------------------------------------------------------------------------------------------------------
Version 1.3:
Print and preview (copy 100% from here: https://support.microsoft.com/en-us/help/812425/how-to-print-the-content-of-a-richtextbox-control-by-using-visual-c-.net-or-visual-c-2005)
Basic Find and Replace
Basic AutoBraceMatching and AutoIndentation (the idea from scintilla: https://github.com/jacobslusser/ScintillaNET/issues/35)
Preferences setting (used xml file to save user preferences)

----------------------------------------------------------------------------------------------------------------------------------------------------
Version 1.4:
Basic Code folding
