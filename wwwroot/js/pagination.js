
    document.addEventListener("DOMContentLoaded", function () {
        const rowsPerPage = 5; // Number of rows to display per page
        const table = document.getElementById("PatientTable").getElementsByTagName("tbody")[0];
        const rows = table.getElementsByTagName("tr");
        const totalPages = Math.ceil(rows.length / rowsPerPage);
        const paginationControls = document.getElementById("paginationControls");

        function displayPage(page) {
            // Hide all rows
            for (let i = 0; i < rows.length; i++) {
                rows[i].style.display = "none";
            }

            // Calculate the start and end index for the rows to show
            const start = (page - 1) * rowsPerPage;
            const end = Math.min(start + rowsPerPage, rows.length);

            // Show rows for the current page
            for (let i = start; i < end; i++) {
                rows[i].style.display = "table-row";
            }
        }

        function setupPagination() {
            // Create pagination buttons
            for (let i = 1; i <= totalPages; i++) {
                const li = document.createElement("li");
                li.className = "page-item";
                const a = document.createElement("a");
                a.className = "page-link";
                a.href = "#";
                a.textContent = i;
                a.addEventListener("click", function (e) {
                    e.preventDefault();
                    displayPage(i);
                    updateActivePage(i);
                });
                li.appendChild(a);
                paginationControls.appendChild(li);
            }

            // Display the first page by default
            displayPage(1);
            updateActivePage(1);
        }

        function updateActivePage(page) {
            // Remove active class from all pagination items
            const pageItems = paginationControls.getElementsByClassName("page-item");
            for (let i = 0; i < pageItems.length; i++) {
                pageItems[i].classList.remove("active");
            }

            // Add active class to the current page item
            pageItems[page - 1].classList.add("active");
        }

        setupPagination();
    });


    function sortTable(tableId, isAscending) {
        var table = document.getElementById(tableId);
        var tbody = table.tBodies[0];
        var rows = Array.from(tbody.querySelectorAll("tr"));

        rows.sort(function (a, b) {
            var cellA = a.children[2].innerText.toLowerCase(); // Sort by the 'Name' column (index 2)
            var cellB = b.children[2].innerText.toLowerCase();

            if (!isNaN(cellA) && !isNaN(cellB)) {
                cellA = parseFloat(cellA);
                cellB = parseFloat(cellB);
            }

            if (isAscending) {
                return cellA > cellB ? 1 : cellA < cellB ? -1 : 0;
            } else {
                return cellA < cellB ? 1 : cellA > cellB ? -1 : 0;
            }
        });

        // Update the table with the sorted rows
        rows.forEach(function (row) {
            tbody.appendChild(row);
        });
    }
