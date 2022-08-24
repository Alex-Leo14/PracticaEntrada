window.onload = function () {

    var data = null;

    var xhr = new XMLHttpRequest();

    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === this.DONE) {
            console.log(this.responseText);
        }
    });

    xhr.open("GET", "https://samsungpe.vtexcommercestable.com.br/api/oms/pvt/orders/1047273050539-01");
    xhr.setRequestHeader("accept", "application/json");
    xhr.setRequestHeader("content-type", "application/json");
    xhr.setRequestHeader("x-vtex-api-appkey", "vtexappkey-samsungpe-BINPKS");
    xhr.setRequestHeader("x-vtex-api-apptoken", "NUPVYHFBHHVDSSESORRDVYRKLMEAUUDAFPTJAQKLGSHYSIQHBLHFJUDOCEJMDFGNEUXCYUSXGGWCRTRDVXYJMYRKMFGVGXHALTTXKNIGSJYCYAWJNGRGGXAGDNQTOXRJ");

    xhr.send(data);

}