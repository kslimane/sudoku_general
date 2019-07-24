# sudoku_general

Plop

La DLL est dans /libs. 

Vous pouvez clone si vous avez les droits ou fork et pull request.
Il serait aimable que vous ajoutiez l'interface ISudokuSolver a votre classe gerant la resolution.

## Organisation

>> Mettez votre projet dans un dossier bien nomme a la racine du repo.


### La classe Sudoku

Class that represents a Sudoku, fully or partially completed
Holds a list of 81 int for cells, with 0 for empty cells
Can parse strings and files from most common formats and displays the sudoku in an easy to read format

#### public Sudoku(IEnumerable<int> cells)
#### public override string ToString()
    Displays a Sudoku in an easy to read format
#### public static Sudoku Parse(string sudokuAsString)
    Parses a single Sudoku
    "sudokuAsString" : the string representing the sudoku
    Returns : the parsed sudoku
#### public List<Sudoku> ParseFile(string fileName)
    Parses a file with one or several sudokus
    Returns : the list of parsed sudokus
#### public static List<Sudoku> ParseMulti(string[] lines)
    Parses a list of lines into a list of sudoku, accounting for most cases usually encountered
    "lines" : the lines of string to parse
    returns : the list of parsed sudokus
    

 
