# sudoku_general

Plop

La DLL est dans /libs. 

Pour l'instant c'est une solution vide. Dans l'absolu l'idee serait surement que les gens la clonent et implementent leur code
dans un fichier par groupe type 'Sudoku_nomdegroupe.cs'.


### La classe Sudoku

Class that represents a Sudoku, fully or partially completed
Holds a list of 81 int for cells, with 0 for empty cells
Can parse strings and files from most common formats and displays the sudoku in an easy to read format

#### public Sudoku(IEnumerable<int> cells)
#### public override string ToString()
    Displays a Sudoku in an easy to read format
#### public static Sudoku Parse(string sudokuAsString)
    Parses a single Sudoku
    "sudokuAsString" :the string representing the sudoku
    Returns : the parsed sudoku
#### public List<Sudoku> ParseFile(string fileName)
    Parses a file with one or several sudokus
    Returns : the list of parsed sudokus
    
    

 
