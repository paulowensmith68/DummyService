﻿<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller

    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer. 
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()

        Me.ServiceProcessInstaller1 = New System.ServiceProcess.ServiceProcessInstaller

        Me.DummyService = New System.ServiceProcess.ServiceInstaller

        '
        'ServiceProcessInstaller1
        '
        Me.ServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.ServiceProcessInstaller1.Password = Nothing
        Me.ServiceProcessInstaller1.Username = Nothing

        '
        'DummyService
        '
        Me.DummyService.Description = "Dummy Service"
        Me.DummyService.DisplayName = "DummyService"
        Me.DummyService.ServiceName = "DummyService"
        Me.DummyService.StartType = System.ServiceProcess.ServiceStartMode.Automatic

        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceProcessInstaller1, Me.DummyService})

    End Sub

    Public Overrides Sub Install(ByVal stateSaver As IDictionary)

        RetrieveServiceName()
        MyBase.Install(stateSaver)

    End Sub

    Public Overrides Sub Uninstall(ByVal stateSaver As IDictionary)

        RetrieveServiceName()
        MyBase.Uninstall(stateSaver)

    End Sub

    Private Sub RetrieveServiceName()

        Dim serviceName As String = Context.Parameters("servicename")
        If Not String.IsNullOrEmpty(serviceName) Then
            Me.DummyService.DisplayName = serviceName
            Me.DummyService.ServiceName = serviceName
        End If

    End Sub

    Friend WithEvents ServiceProcessInstaller1 As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents DummyService As System.ServiceProcess.ServiceInstaller

End Class
