# 🧠 Capítulo 2 — *Meaningful Names (Nombres con significado)*

## 🌍 Introducción
En programación, los nombres están en todas partes: variables, funciones, clases, archivos, módulos…  
Dado que los usamos constantemente, **nombrar bien es una habilidad esencial para escribir código limpio**.  
Un buen nombre no solo identifica un elemento, sino que **explica su propósito, su rol y su contexto**.

> 👉 “Si un nombre necesita un comentario para entenderse, entonces no es un buen nombre.”

---

## 🪞 1. Usa nombres que revelen intención

Un nombre debe responder tres preguntas sin necesidad de comentarios:
- ¿Por qué existe?
- ¿Qué hace?
- ¿Cómo se usa?

### ❌ Ejemplo malo:
```java
int d; // elapsed time in days
```

### ✅ Ejemplo bueno:
```java
int elapsedTimeInDays;
int daysSinceCreation;
```

### Ejemplo de función:
```java
public List<int[]> getThem() { ... }
```
→ No se entiende qué obtiene.

```java
public List<Cell> getFlaggedCells() { ... }
```
→ Se entiende claramente.

---

## ⚠️ 2. Evita la desinformación

Un mal nombre puede confundir.  
Por ejemplo, usar `hp`, `aix`, o `sco` puede parecer que se refiere a sistemas Unix.  
También evita usar nombres que den a entender una estructura que no existe.

### ❌ Ejemplo:
```java
accountList // pero no es una lista, es un arreglo
```

### ✅ Ejemplo:
```java
accountGroup
accounts
```

**Regla:** No uses nombres que engañen. La claridad está por encima de la brevedad.

---

## 🧩 3. Haz distinciones significativas

Si dos cosas tienen nombres diferentes, **deben significar cosas diferentes**.  
Evita añadir palabras sin valor (“Info”, “Data”, “Object”) solo para que compile.

### ❌ Ejemplo:
```java
ProductData
ProductInfo
ProductObject
```

### ✅ Ejemplo:
```java
Product
ProductRepository
```

Evita también nombres genéricos como `a1`, `a2` o `theMessage`.

---

## 🗣️ 4. Usa nombres pronunciables

El lenguaje humano es fonético; si un nombre no se puede pronunciar, **no se puede discutir fácilmente**.

### ❌ Ejemplo:
```java
class DtaRcrd102 {
    private Date genymdhms;
    private Date modymdhms;
}
```

### ✅ Ejemplo:
```java
class CustomerRecord {
    private Date generationTimestamp;
    private Date modificationTimestamp;
}
```

> Esto permite que los programadores se comuniquen fluidamente sobre el código.

---

## 🔍 5. Usa nombres fáciles de buscar

### ❌ Ejemplo:
```java
if (studentCount > 7) ...
```

### ✅ Ejemplo:
```java
if (studentCount > MAX_CLASSES_PER_STUDENT) ...
```

**Regla práctica:**  
Usa nombres cortos solo para variables locales (`i`, `j`, `k`) en bucles pequeños.  
En todo lo demás, **elige nombres buscables y claros.**

---

## 🧮 6. Evita codificaciones y prefijos innecesarios

### ❌ Ejemplo:
```java
private String m_dsc;
```

### ✅ Ejemplo:
```java
private String description;
```

El IDE ya resalta los miembros de clase y su tipo.  
Evita usar codificación “húngara” o cualquier convención obsoleta.

---

## 🧭 7. Evita el *mental mapping*

### ❌ Ejemplo:
```java
int r; // resultado de la resta
```

### ✅ Ejemplo:
```java
int difference;
```

> Los nombres cortos solo son aceptables cuando su significado es universalmente entendido (`i`, `j`, `k`).

---

## 🧱 8. Clases y métodos: reglas de nombres

- **Clases y objetos:** deben tener nombres **de sustantivos**.  
- **Métodos:** deben tener **verbos**.

### Ejemplo:
```java
employee.getName();
customer.setName("Juan");
if (order.isPaid()) ...
```

---

## 🧠 9. Sé consistente con los términos

### ❌ Ejemplo:
```java
customer.fetchOrders();
client.retrieveOrders();
```

### ✅ Ejemplo:
```java
customer.getOrders();
client.getOrders();
```

---

## 🤹 10. No hagas juegos de palabras

Evita reutilizar el mismo nombre con significados distintos.

```java
sum.add();     // suma valores
list.append(); // agrega elementos
```

---

## 🏗️ 11. Usa nombres del dominio del problema o de la solución

- **Solución:** `JobQueue`, `FactoryPattern`
- **Problema:** `Invoice`, `CustomerOrder`

Combinar ambos con juicio hace el código más natural.

---

## 🧩 12. Agrega contexto significativo

### ❌ Ejemplo:
```java
String city, state, zip;
```

### ✅ Ejemplo:
```java
class Address {
    String city;
    String state;
    String zip;
}
```

---

## 🚫 13. No agregues contexto innecesario

### ❌ Ejemplo:
```java
class GSDAccountAddress {}
```

### ✅ Ejemplo:
```java
class AccountAddress {}
class CustomerAddress {}
```

---

## 💬 14. Reflexión final

Elegir nombres buenos no es solo técnica, sino **comunicación clara y empática**.  
Refactorizar nombres **es una inversión**.  
El código debe leerse como un texto, no como un acertijo.

---

## 💡 Resumen final

| Principio | Qué busca | Ejemplo correcto |
|------------|------------|------------------|
| Revelar intención | Claridad semántica | `elapsedTimeInDays` |
| Evitar desinformación | Nombres honestos | `accountGroup` |
| Distinción significativa | Nombres con sentido | `ProductRepository` |
| Pronunciables | Comunicación oral clara | `generationTimestamp` |
| Buscables | Mantenimiento fácil | `MAX_CLASSES_PER_STUDENT` |
| Sin codificaciones | Limpieza visual | `description` |
| Contexto útil | Significado agrupado | `Address.city` |
| Sin contexto redundante | Brevedad útil | `AccountAddress` |
