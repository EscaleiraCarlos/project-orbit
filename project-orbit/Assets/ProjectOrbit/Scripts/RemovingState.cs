using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RemovingState : IBuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData magnetsData;
    ObjectPlacer objectPlacer;

    public RemovingState(Grid grid,
                         PreviewSystem previewSystem,
                         GridData magnetsData,
                         ObjectPlacer objectPlacer)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.magnetsData = magnetsData;
        this.objectPlacer = objectPlacer;

        previewSystem.StartShowingRemovePreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        if(magnetsData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false)
        {
                      selectedData = magnetsData;
        }

        if(selectedData == null)
        {
            //sound
        }
        else
        {
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if (gameObjectIndex == -1)
                return;
            selectedData.RemoveObjectAt(gridPosition);
            objectPlacer.RemoveObjectAt(gameObjectIndex);
        }
        Vector3 cellPosition = grid.CellToWorld(gridPosition);
        previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        return !(magnetsData.CanPlaceObjectAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = CheckIfSelectionIsValid(gridPosition);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}
