using ClientLibrary.Services.Contracts;

public class AppState<T>
{
    private readonly IGenericServiceInterface<T> _service;
    private readonly string _baseUrl;

    public AppState(IGenericServiceInterface<T> service, string baseUrl)
    {
        _service = service;
        _baseUrl = baseUrl;
    }

    public List<T> Items { get; private set; } = new();

    public event Action? OnStateChange;

    public async Task LoadItemsAsync()
    {
        Items = await _service.GetAll(_baseUrl);
        NotifyStateChanged();
    }

    public async Task AddItem(T item)
    {
        var response = await _service.Insert(item, _baseUrl);
        // Handle response if necessary
        // Refresh items if insertion is successful
        if (response != null && response.Flag)
        {
            await LoadItemsAsync();
        }
    }

    public async Task UpdateItem(T item)
    {
        var response = await _service.Update(item, _baseUrl);
        // Handle response if necessary
        // Refresh items if update is successful
        if (response != null && response.Flag)
        {
            await LoadItemsAsync();
        }
    }

    public async Task DeleteItem(int id)
    {
        var response = await _service.DeleteById(id, _baseUrl);
        // Handle response if necessary
        // Refresh items if deletion is successful
        if (response != null && response.Flag)
        {
            await LoadItemsAsync();
        }
    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}