
// (ASP.NET Core)
// Store
HttpContext.Session.SetString("Verification", "Verified");

// Read
string verification = HttpContext.Session.GetString("Verification");

if (verification == "Verified")
{
    // User is verified
}

// Remove
HttpContext.Session.Remove("Verification");

// Clear all session values
HttpContext.Session.Clear();

// (ASP.NET MVC 5)
// Store
Session["Verification"] = "Verified";

// Read
string verification = Session["Verification"]?.ToString();

if (verification == "Verified")
{
    // User is verified
}

// Remove
Session.Remove("Verification");

// Clear all session values
Session.Clear();
