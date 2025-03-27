public class PrinterDriver {
    private Printer printer;
    private IInputDevice device; 

    public PrinterDriver(Printer printer, IInputDevice device) {
        this.printer = printer;
        this.device = device;
    }

    public void Print() {
        while(device.IsEndOfData() == false) {
            printer.Print(device.ReadPage());
        }
    }
}

public interface IInputDevice {
    public buffer ReadPage();
    public bool IsEndOfData();
}

public class File : IInputDevice {
    private string path;
    private StreamReader reader;

    public File(string path) {
        this.path = path;
        reader = new StreamReader(path);
    }

    public override buffer ReadPage() {
        return reader.ReadLine();
    }

    public override bool IsEndOfData() {
        return reader.EndOfStream;
    }
}

public class ScannerService : IInputDevice {
    private Scanner scanner;

    public ScannerService() {
        scanner = new Scanner();
    }

    public override buffer ReadPage() {
        return scanner.Scan();
    }

    public override bool IsEndOfData() {
        return scanner.IsEndOfData();
    }
}

public class FaxService : IInputDevice {
    private Fax fax;

    public FaxService() {
        fax = new Fax();
    }

    public override buffer ReadPage() {
        return fax.Receive();
    }

    public override bool IsEndOfData() {
        return fax.IsEndOfData();
    }
}