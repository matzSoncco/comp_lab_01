# Laboratorio 1: Simulación de Dinámicas Físicas en Voleibol 2D

## Descripción del Proyecto
Este proyecto consiste en una simulación interactiva de un encuentro de voleibol desarrollada en **Unity 2022.3+**. El objetivo principal es la implementación de un **Sistema Universal de Referencia (SUR)** sólido, donde dos agentes (representados por primitivas circulares) interactúan con un proyectil (pelota) bajo leyes de física clásica y detección de colisiones por triggers

## Arquitectura Técnica
*   **Motor de Física:** Rigidbody 2D con detección de colisiones continua para evitar el efecto túnel
*   **Coordenadas (SUR):** El origen $(0,0,0)$ se sitúa en la base de la red, dividiendo el espacio en subdominios de juego para el Jugador 1 ($x < 0$) y el Jugador 2 ($x > 0$)
*   **Diseño Modular:** Se utiliza una arquitectura de **Entidad-Componente**, separando la lógica de control del agente de su representación visual

## Controles de Juego
El sistema soporta modo local multijugador:

| Acción | Jugador 1 | Jugador 2 |
| :--- | :--- | :--- |
| **Moverse** | `A` / `D` | `Flecha Izquierda` / `Derecha` |
| **Saltar** | `W` | `Flecha Arriba` |

## Estado de la Simulación (Nota Técnica)
Actualmente, el sistema opera bajo un modelo de **Simulación Continua (Open Loop)**
*   **Detección de Puntos:** Los `PointArea` detectan el contacto del proyectil con el suelo y actualizan el marcador en tiempo real
*   **Condición de Victoria:** Al tratarse de un prototipo enfocado en la validación de leyes físicas en el SUR (Laboratorio 1), la simulación no posee un límite de puntos definido, permitiendo pruebas extensivas de colisión y rebote sin interrupción de flujo

## Instalación y Ejecución
1.  Clonar el repositorio
2.  Abrir la carpeta del proyecto en **Unity Hub**
3.  Cargar la escena `SampleScene` en la carpeta `Assets/Scenes`
4.  Para el ejecutable, revisar releases de github

---
**Autor:** Max Junior Soncco Mamani