public class PrinterDriver
{
    private Printer _printer;
    private File _file;
    private Scanner _scanner;
    private Fax _fax;

    public PrinterDriver(File file, Printer printer)
    {
        _file = file;
        _printer = printer;
        _scanner = null;
        _fax = null;
    }

    public PrinterDriver(Scanner scanner, Printer printer)
    {
        _file = null;
        _printer = printer;
        _scanner = scanner;
        _fax = null;
    }

    public PrinterDriver(Fax fax, Printer printer)
    {
        _file = null;
        _printer = printer;
        _scanner = null;
        _fax = fax;
    }

    public void Print()
    {
        if(this._file != null) {
            buffer page = _file.Read();
            while(page != null) {
                _printer.Print(page);
                page = _file.Read();
            }
        } 
        else if(this._scanner != null) {
            buffer page = _scanner.Scan();
            while(page != null) {
                _printer.Print(page);
                page = _scanner.Scan();
            }
        } 
        else {
            buffer page = _fax.Receive();
            while(page != null) {
                _printer.Print(page);
                page = _fax.Receive();
            }
        }
    }
}