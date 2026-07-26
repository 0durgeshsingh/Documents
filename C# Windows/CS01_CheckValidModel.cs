                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new
                        {
                            Field = x.Key,
                            Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                        });

                    foreach (var item in errors)
                    {
                        Console.WriteLine(item.Field);
                        foreach (var err in item.Errors)
                        {
                            Console.WriteLine(err);
                        }
                    }
                }

// error Handling in Controller 