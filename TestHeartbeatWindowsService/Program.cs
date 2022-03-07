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

int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
Environment.Exit(exitCodeValue);