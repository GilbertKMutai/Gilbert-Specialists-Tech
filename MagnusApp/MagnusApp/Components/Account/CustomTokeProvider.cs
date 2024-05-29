using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MagnusApp.Shared.Configuration;

//Custom Token provider for Email and Password 
public class CustomEmailConfirmationTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
    public CustomEmailConfirmationTokenProvider(
        IDataProtectionProvider dataProtectionProvider, 
        IOptions<EmailConfirmationTokenProviderOptions> options,
        ILogger<DataProtectorTokenProvider<TUser>> logger
        ) : base(dataProtectionProvider, options, logger)
    {
    }
}

public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public EmailConfirmationTokenProviderOptions()
    {
        Name = "EmailDataProtectorTokenProvider";
        TokenLifespan = TimeSpan.FromHours(4);
    }
}


public class CustomPasswordResetTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
    public CustomPasswordResetTokenProvider(
        IDataProtectionProvider dataProtectionProvider, 
        IOptions<PasswordResetTokenProviderOptions> options,
        ILogger<DataProtectorTokenProvider<TUser>> logger
        ) : base(dataProtectionProvider, options, logger)
    {
    }
}

public class PasswordResetTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public PasswordResetTokenProviderOptions()
    {
        Name = "PasswordDataProtectorTokenProvider";
        TokenLifespan = TimeSpan.FromHours(3);
    }
}