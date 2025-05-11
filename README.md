# BCCR.TipoCambio 🏦🔄

**BCCR.TipoCambio** es un servicio de Windows desarrollado en .NET 8 que consume el tipo de cambio oficial desde el API REST del Banco Central de Costa Rica (BCCR) y lo guarda en una tabla del sistema **Nuba Hotel**.

El proyecto implementa **Clean Architecture**, separación clara por capas, uso de **casos de uso**, **repositorios**, **mappers manuales**, y se apoya en tecnologías modernas como **Entity Framework Core**, **FluentValidation** e **Inyección de Dependencias**.

---

## 🧱 Arquitectura del Proyecto

```
BCCR.TipoCambio
├── Aplicacion         → Casos de uso (UseCases) e interfaces
├── Dominio            → Entidades, excepciones y contratos
├── Externas           → Conexión al API del BCCR
├── Infraestructura    → EF Core, contexto, entidades de persistencia, mapeos, logs
└── ServicioWindows    → Worker que ejecuta el proceso de actualización
```

---

## 🚀 Tecnologías Utilizadas

* .NET 8
* Entity Framework Core
* FluentValidation
* Inyección de Dependencias (Microsoft.Extensions.DependencyInjection)
* Clean Architecture
* Windows Service Worker

---

