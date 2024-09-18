# CustomMetricsPOC
<span>This is a sample dockerized web API CRUD as a sole purpose to be a start point to work with Prometheus custom metrics and Grafana.</span>
<span>What actually was done? It was created a custom gauge metric to scrape orders from database using a background job to keep constantly up to date.</span>

### Tech Stacks
<ul>
  <li>
    Docker
    <img src="https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white" alt="Docker Badge" />
  </li>
  <li>
    .NET 8
    <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=".NET 8 Badge" />
  </li>
  <li>
    SQLite
    <img src="https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white" alt="SQLite Badge" />
  </li>
</ul>

### About Prometheus
<span>The following dashboard template was used: <a href="https://grafana.com/grafana/dashboards/10427-prometheus-net/">prometheus-net</span>

### Custom dashboard
<span>Please download the custom dashboard.</span> <br/>
<span>You need to change the stat panel to the following metric and label filter: <code>total_order_count </code> and <code>job = csharp-app</code></span>
<img src="https://github.com/user-attachments/assets/1a067837-4c93-4c43-8712-3509f468b405" width="700" height="auto">
<img src="https://github.com/user-attachments/assets/df584da8-728d-481c-bfd5-50244f032347" width="900" height="auto">

### PS ⚠️
<span>The final stage image uses the <code>bookworm-slim</code> tag, which is smaller but do not contains tzdata, resulting on lack of globalization.</span><br/>
<span>That's why there is no data at <code>Start time of the process</code> panel.<span>
