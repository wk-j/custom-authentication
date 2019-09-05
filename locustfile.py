from locust import HttpLocust, TaskSet, task


class WebsiteTasks(TaskSet):
    def on_start(self):
        self.client.get("/api/account/login/1234")

    @task
    def get_computers(self):
        url = f"/api/data/getComputers"
        self.client.get(url)

    @task
    def index(self):
        self.client.get("/weatherForecast")


class WebsiteUser(HttpLocust):
    task_set = WebsiteTasks
    min_wait = 5000
    max_wait = 15000
