const loading=document.querySelector('.loading');
const scrollToTop=document.querySelector('.scroll_to_top');
const contact=document.querySelector('.contact0');
let valueDisplays=document.querySelectorAll('.number');
let header=document.querySelector('header');
// let happy=document.querySelector('.customer');
let fullImgView=document.getElementById('fullImgView');
// let happy_customer=document.querySelector('.full-case')
const zoom=document.querySelectorAll('.zoom');
const fullImg=document.querySelector('#fullImg');
let src1="assets/img/customer/gallery-1.jpg";
let src2="assets/img/customer/gallery-2.jpg";
let src3="assets/img/customer/gallery-3.jpg";
let src4="assets/img/customer/gallery-4.jpg";
let interval=4000;
window.addEventListener('load',function(){
this.setTimeout(function(){
loading.classList.add('opacity-0','invisible')
document.body.style.overflowY='auto'
},2000)
})
scrollToTop.addEventListener('click',function(){
    window.scroll({
        top:0,
        behavior:'smooth',
    })
})
window.addEventListener('scroll',function(){

    if(window.scrollY > header.offsetHeight)
    {    
        scrollToTop.classList.remove('opacity-0','invisible');
    }
    else
    {   
        scrollToTop.classList.add('opacity-0','invisible');
    }
})
zoom.forEach((element)=>
    element.addEventListener('click',function(){
        event.preventDefault();
        fullImgView.classList.remove("d-none");
    if(element.getAttribute('count')==1)
    fullImg.setAttribute('src',src1);
else if(element.getAttribute('count')==2)
fullImg.setAttribute('src',src2);
else if(element.getAttribute('count')==3)
fullImg.setAttribute('src',src3);
else
fullImg.setAttribute('src',src4);

})
)
fullImgView.addEventListener('click',function(){
    fullImgView.classList.add("d-none");
})







