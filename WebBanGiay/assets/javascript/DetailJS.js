let currentIndex = 0;

function changeImage(index) {
    currentIndex = index;
    document.getElementById("mainImage").src = productImages[index];
}

document.getElementById("prevBtn").addEventListener("click", function () {
    currentIndex = (currentIndex - 1 + productImages.length) % productImages.length;
    changeImage(currentIndex);
});

document.getElementById("nextBtn").addEventListener("click", function () {
    currentIndex = (currentIndex + 1) % productImages.length;
    changeImage(currentIndex);
});

// Chọn size
let selectedSize = null;

function selectSize(button, idSize) {
    document.querySelectorAll(".size-btn").forEach(btn => {
        btn.classList.remove("active", "btn-dark");
        btn.classList.add("btn-outline-secondary");
    });
    button.classList.remove("btn-outline-secondary");
    button.classList.add("btn-dark", "active");
    selectedSize = idSize;
}

// Số lượng
let quantity = 1;
function changeQuantity(delta) {
    quantity = Math.max(1, quantity + delta);
    document.getElementById("quantity").value = quantity;
}

// Thêm vào giỏ hàng
function addToCart() {
    if (!selectedSize) {
        alert("Vui lòng chọn size trước khi thêm vào giỏ hàng!");
        return;
    }
    const qty = document.getElementById("quantity").value;
    window.location.href = `/Cart/AddToCart?productId=${productId}&size=${selectedSize}&qty=${qty}`;
}
