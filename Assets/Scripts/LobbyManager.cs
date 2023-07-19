using Coherence.Cloud;
using Coherence.Runtime;
using Coherence.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public CoherenceBridge bridge;
    public IRoomsService roomsService;
    public bool joinNextCreatedRoom = true;
    public TMP_InputField textInputField;
    
    private ReplicationServerRoomsService replicationServerRoomsService;
    private string roomName;

    private void OnEnable()
    {
        replicationServerRoomsService ??= new ReplicationServerRoomsService();
        roomsService = replicationServerRoomsService;
    }

    // Start is called before the first frame update
    void Start()
    {
        bridge = FindObjectOfType<CoherenceBridge>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void CreateRoom()
    {
        var options = RoomCreationOptions.Default;
        options.KeyValues.Add(RoomData.RoomNameKey, textInputField.text);
        options.MaxClients = 10;

        roomsService?.CreateRoom(OnRoomCreated, options);
    }

    public void JoinRoom(RoomData roomData)
    {
        bridge.JoinRoom(roomData);
        Play();
    }

    private void OnRoomCreated(RequestResponse<RoomData> requestResponse)
    {
        if (!AssertRequestResponse("Error during room creation", requestResponse.Status, requestResponse.Exception))
        {
            joinNextCreatedRoom = false;
            return;
        }

        var createdRoom = requestResponse.Result;
        if (joinNextCreatedRoom)
        {
            joinNextCreatedRoom = false;
            JoinRoom(createdRoom);
        }
        else
        {

        }
    }

    private bool AssertRequestResponse(string title, RequestStatus status, Exception exception)
    {
        if (status == RequestStatus.Success)
        {
            return true;
        }

        return false;
    }

    public void FindRoom()
    {
        roomsService.FetchRooms(OnFetchRooms);
        roomName = textInputField.text;
    }

    private void OnFetchRooms(RequestResponse<IReadOnlyList<RoomData>> requestResponse)
    {
        var rooms = requestResponse.Result;

        if (!AssertRequestResponse("Error while fetching available rooms", requestResponse.Status, requestResponse.Exception))
        {
            return;
        }

        if (rooms.Count == 0)
        {
            return;
        }

        var foundroom = rooms.FirstOrDefault(room => room.RoomName == roomName);

        if(foundroom.Id != 0)
        {
            JoinRoom(foundroom);
        }
    }
}
