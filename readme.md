# ProgressBar Library

The ProgressBar library provides a simple and customizable progress bar for console applications in C#.

## Configuration

The `ProgressBarOptions` class allows you to configure various aspects of the progress bar:

| Option               | Description                                                           |
|----------------------|-----------------------------------------------------------------------|
| Width                | Width of the progress bar in characters.                              |
| Prefix               | Prefix to be displayed before the progress bar.                       |
| Filler               | Character used to fill the progress bar.                              |
| Arrow                | Character representing the progress indicator.                        |
| Color                | Color of the progress bar (optional).                                 |
| DisplayElapsedTime   | Indicates whether to display elapsed time alongside the progress bar. |

## Installation

You can install the ProgressBar library via NuGet Package Manager:

```
Install-Package Bardin08.ProgressBar
```

## Usage

1. **Create ProgressBarOptions**:

   ```csharp
   var options = new ProgressBarOptions
   {
       Width = 50,
       Prefix = "Progress: ",
       Filler = '=',
       Arrow = '>',
       Color = ConsoleColor.Green,
       DisplayElapsedTime = true
   };
   ```

2. **Instantiate ProgressBar**:

   ```csharp
   long totalTicks = 1000;
   var progressBar = new ProgressBar(totalTicks, options);
   ```

3. **Update Progress**:

   Call the `Update` method to update the progress bar:

   ```csharp
   progressBar.Update(10); // Increment progress by 10 ticks
   ```

4. **Finish**:

   Call the `Finish` method to stop the progress bar and output a newline:

   ```csharp
   progressBar.Finish();
   ```

## Example

```csharp
var options = new ProgressBarOptions
{
   Width = 50,
   Prefix = "Progress: ",
   Filler = '=',
   Arrow = '>',
   Color = ConsoleColor.Green,
   DisplayElapsedTime = true
};

long totalTicks = 1000;
var progressBar = new ProgressBar(totalTicks, options);

for (int i = 0; i < totalTicks; i += 10)
{
   progressBar.Update(10);
   await Task.Delay(100); // Simulate work
}

progressBar.Finish();
```
