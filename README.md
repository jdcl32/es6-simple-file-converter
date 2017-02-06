# es6-simple-file-converter
A simple es6 file converter
 

## Dependecies

.NET CORE 1.1.0
* [for Windows users, dowload .NET Core](https://www.microsoft.com/net/core#windowscmd)
* For Ubuntu/Mint users:
    1. Add the dotnet apt-get feed
        * Ubuntu 14.04 / Linux Mint 17
            ```
            sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
            sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
            sudo apt-get update
            ```
        * Ubuntu 16.04
            ```
            sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
            sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
            sudo apt-get update
            ```
        * Ubuntu 16.10
            ```
            sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ yakkety main" > /etc/apt/sources.list.d/dotnetdev.list'
            sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
            sudo apt-get update
            ```
    2. Install .NET Core
        ```
        sudo apt-get install dotnet-dev-1.0.0-preview2.1-003177
        ```
* For Mac Users
    1. 	Install pre-requisites
        ```
        brew update
        brew install openssl
        mkdir -p /usr/local/lib
        ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/
        ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/
        ```
    2. [Dowload and run official installer ](https://go.microsoft.com/fwlink/?LinkID=835011)

* [Here for information about others OS and distro](https://www.microsoft.com/net/core)

## Installing the app
1. open a terminal/command prompt
2. move to the app root directory
3. run `dotnet restore` 

## Using the app
1. open a terminal/command prompt
2. move to the app root directory
3. Run `dotnet run src [dest]`

### Rules
* *src* is a file or directory to convert
* if *src* is a directory all files inside will be converted. 
* *dest* is a file or directory to put the converted files.
* if *dest* is a directory, all files converted will be put inside with the same name.
* if *dest* is a file, all files converted will be appended to this file, if the file exists it will be overwritten.

### Limitations
* If the *dest* directory don't exists the app will try to create it but will fail if is not posible.