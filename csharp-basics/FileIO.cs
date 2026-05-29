// FileExistsDemo();
// ReadTextDemo();
// WriteTextDemo();
// ReadLinesDemo();
// AppendTextDemo();
// PathDemo();
// DirectoryDemo();
// FileInfoDemo();
// AsyncFileDemo();


// =====================================================
// 1. FILE EXISTS
// =====================================================

void FileExistsDemo()
{
    bool exists = File.Exists("data.txt");
    Console.WriteLine(exists);
}

/*
File.Exists()
Checks whether file exists
Returns:
- true
- false
*/


// =====================================================
// 2. READ TEXT
// =====================================================

void ReadTextDemo()
{
    string content = File.ReadAllText("data.txt");
    Console.WriteLine(content);
}

/*
ReadAllText()
Reads entire file

Returns:
string

Throws if:
- file missing
- access denied
*/


// =====================================================
// 3. WRITE TEXT
// =====================================================

void WriteTextDemo()
{
    File.WriteAllText("data.txt", "Hello World");
    Console.WriteLine("File written");
}

/*
WriteAllText()
- Creates file if needed
- Overwrites existing content
*/


// =====================================================
// 4. READ LINES
// =====================================================

void ReadLinesDemo()
{
    string[] lines = File.ReadAllLines("data.txt");

    foreach (string line in lines)
    {
        Console.WriteLine(line);
    }
}

/*
ReadAllLines()

Returns:
string[]

One element per line
*/


// =====================================================
// 5. APPEND TEXT
// =====================================================

void AppendTextDemo()
{
    File.AppendAllText("log.txt", "New log entry\n");
    Console.WriteLine("Text appended");
}

/*
AppendAllText()
- Adds text to file
- Does not overwrite existing content
*/


// =====================================================
// 6. PATH
// =====================================================

void PathDemo()
{
    string path = Path.Combine(
        "Data",
        "Users",
        "users.txt"
    );

    Console.WriteLine(path);
}

/*
Path:
Utility class for working with paths

Path.Combine()

Builds paths safely
*/


// =====================================================
// 7. DIRECTORY
// =====================================================

void DirectoryDemo()
{
    Directory.CreateDirectory("Logs");

    bool exists = Directory.Exists("Logs");
    Console.WriteLine(exists);
}

/*
Directory:
Work with folders

CreateDirectory():
Creates folder

No error if already exists
*/


// =====================================================
// 8. FILEINFO
// =====================================================

void FileInfoDemo()
{
    FileInfo file = new("data.txt");

    Console.WriteLine(file.Exists);

    if (file.Exists)
    {
        Console.WriteLine(file.Length);
        Console.WriteLine(file.Extension);
        Console.WriteLine(file.Name);
    }
}

/*
FileInfo:
Object-oriented API

Useful properties:
- Exists
- Length
- Extension
- Name
- CreationTime
*/


// =====================================================
// 9. ASYNC FILE I/O
// =====================================================

async Task AsyncFileDemo()
{
    string content = await File.ReadAllTextAsync("data.txt");
    Console.WriteLine(content);
}

/*
Async file operations

ReadAllTextAsync()
Returns:
Task<string>

Works with:
async / await
*/
