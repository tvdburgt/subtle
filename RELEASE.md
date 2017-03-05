# Release procedure

1. Update `Subtle.Gui\Properties\AssemblyInfo.cs`
2. **Subtle.Setup** > Properties (F4) > Update Version and generate a new ProductCode
3. Build **Subtle.Setup** using `Release` configuration
4. Run `release\release.cmd` and distribute `release\Subtle.exe`
