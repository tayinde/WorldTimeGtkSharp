# WorldTimeGtkSharp
## Overview
This is a simple app that tells the time of a location. It uses GTK for its GUI.
## Run
To run this program you will need the [.NET Core CLI](https://dotnet.microsoft.com/download) installed to your machine. After that, you can simply run the program by typing `dotnet run` in the root directory of the project.
***
![Example of the app](img/example.png)
## Your own API Key?
<<<<<<< HEAD
To use your own API key from [World Weather Online](https://www.worldweatheronline.com/), you can use it by locating the [APIRequest.cs](https://github.com/tayinde/WorldTimeGtkSharp/blob/a3d80b67c8e91104a767ada1db395a04e8dc1aac/APIRequest.cs#L16) file, going to line 16, and then replacing "your key" in `key.setValue("your key");` to with API key.
=======
If you have your own API key from [World Weather Online](https://www.worldweatheronline.com/), you can use it by locating the [APIRequest.cs](https://github.com/tayinde/WorldTimeGtkSharp/blob/a3d80b67c8e91104a767ada1db395a04e8dc1aac/APIRequest.cs#L16) file, going to line 16, and then replacing "public key" in `key.setValue("public key");` to your API key.
>>>>>>> 4450279c07be94b1ba901027a49d6e4853bd177e
