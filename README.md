Problema con Rigidbody en Unity
Descripción del Problema
Estoy desarrollando un proyecto en Unity y me he encontrado con un problema relacionado con el componente Rigidbody. Al intentar ejecutar el juego, Unity me muestra un error indicando que el Rigidbody no está asignado. Este es el mensaje de error exacto que recibo:

UnassignedReferenceException: The variable rb of player_move has not been assigned.
You probably need to assign the rb variable of the player_move script in the inspector.
UnityEngine.Rigidbody.AddForce (UnityEngine.Vector3 force, UnityEngine.ForceMode mode) (at <62315e55df454945b72a1fd1878414c1>:0)
UnityEngine.Rigidbody.AddForce (System.Single x, System.Single y, System.Single z, UnityEngine.ForceMode mode) (at <62315e55df454945b72a1fd1878414c1>:0)
player_move.Update () (at Assets/Scenes/script/player_move.cs:60)

