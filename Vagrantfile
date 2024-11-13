Vagrant.configure("2") do |config|
  config.vm.network "private_network", ip: "192.168.50.4"
  config.vm.synced_folder ".", "/home/vagrant/CrossPlatformLabs-9"

  # Конфігурація для Ubuntu
  config.vm.define "ubuntu_vm" do |ubuntu|
    ubuntu.vm.box = "ubuntu/focal64"
    ubuntu.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"
      vb.cpus = 4
    end
    ubuntu.vm.provision "shell", inline: <<-SHELL
      sudo apt update && sudo apt upgrade -y
      wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      sudo apt update
      sudo apt-get install -y dotnet-sdk-8.0

      sudo apt install -y docker.io
      sudo systemctl start docker
      sudo systemctl enable docker
      sudo docker pull loicsharma/baget
      sudo docker run -d -p 5000:80 --name baget loicsharma/baget

      export PATH="$PATH:/home/vagrant/.dotnet/tools"
      dotnet nuget add source "http://192.168.50.1:5000/v3/index.json" -n "MainMachineBaGet" --configfile /home/vagrant/.config/NuGet/NuGet.Config
      dotnet tool install --global GK_Lab4Tool --version 1.0.0 --add-source "http://192.168.50.1:5000/v3/index.json"
    SHELL
  end

  # Конфігурація для Windows
  config.vm.define "windows_vm" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"
    windows.vm.communicator = "winrm"
    windows.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"
      vb.cpus = 4
    end
    windows.vm.provision "shell", inline: <<-SHELL
      Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

      choco install dotnet-sdk --version=8.0 -y

      choco install docker-desktop -y
      Start-Service docker
      docker pull loicsharma/baget
      docker run -d -p 5000:80 --name baget loicsharma/baget

      $Env:Path += ";$Env:USERPROFILE\\.dotnet\\tools"
      dotnet nuget add source "http://192.168.50.1:5000/v3/index.json" -n "MainMachineBaGet" --configfile $Env:APPDATA\\NuGet\\NuGet.Config
      dotnet tool install --global GK_Lab4Tool --version 1.0.0 --add-source "http://192.168.50.1:5000/v3/index.json"
    SHELL
  end

  # Конфігурація для macOS
  config.vm.define "mac_vm" do |mac|
    mac.vm.box = "tas50/macos_10.15"
    mac.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"
      vb.cpus = 4
    end
    mac.vm.provision "shell", inline: <<-SHELL
      /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
      export PATH="/opt/homebrew/bin:$PATH"

      brew install --cask dotnet-sdk

      brew install --cask docker
      open /Applications/Docker.app
      docker pull loicsharma/baget
      docker run -d -p 5000:80 --name baget loicsharma/baget

      export PATH="$PATH:/Users/vagrant/.dotnet/tools"
      dotnet nuget add source "http://192.168.50.1:5000/v3/index.json" -n "MainMachineBaGet" --configfile /Users/vagrant/.nuget/NuGet.Config
      dotnet tool install --global GK_Lab4Tool --version 1.0.0 --add-source "http://192.168.50.1:5000/v3/index.json"
    SHELL
  end
end
