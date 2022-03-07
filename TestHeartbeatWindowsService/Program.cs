// See https://aka.ms/new-console-template for more information
using TestHeartbeatWindowsService;
using Topshelf;

var exitCode = HostFactory.Run(s =>
{
    s.Service<Heartbeat>(a =>
    {
        a.ConstructUsing(srv => new Heartbeat());
        a.WhenStarted(srv => srv.Start());
        a.WhenStopped(srv => srv.Stop());
    });
    s.RunAsLocalSystem();
    s.SetServiceName("WindowsServiceTopshelf");
    s.SetDisplayName("Windows Service Topshelf");
    s.SetDescription("This is the service with topshelf");

});

/*
 

for publish to services of pc

1. copy bin file to another directory of file

2. open another file from command Administator.

3. "TestHeartbeatWindowsService.exe install start" run this command 

created by Musa Adsız
https://github.com/adsizmusa/WindowsServiceTopshelf
https://www.linkedin.com/in/adsizmusa/


 
 */

int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
Environment.Exit(exitCodeValue);