# MiddleSchoolHelper2000
Assigned lines as a punishment? Let the MiddleSchoolHelper2000 do it for you! Lines have not been proven to have a positive effect on the efficacy of education of children.

Get out of the house and play something or learn something useful! Computer programming is a great idea, by the way...


# To run this project 
1) Clone or download the repo.
2) run "dotnet restore" in a terminal while in the root directory.
3) Run "dotnet run" or "dotnet watch run"
4) Navigate to "localhost:5000" on your browser (this may depend on what port your localhost process starts up in. Check your terminal output after the "dotnet run" command runs.


#Documentation
The MiddleSchoolHelper2000 wraps each letter in a span element (horrible, I know) and then applies a randomly chosen font-style to each span.
The font are imported on the _Layout.cshtml page from Google Fonts and were chosen as they appear to be roughly the same handwriting style, attempting to avoid drawing attention to the handwriting itself.
The function looks for periods (.), exclamation points (!), or question marks (?) in order to determine when to begin a new line. If you don't put any of those symbols, the output will just be one long line.
