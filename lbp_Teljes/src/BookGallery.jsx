import React from 'react';
import './BookGallery.css';
import { Link } from 'react-router-dom';
function BookGallery() {
  return (
    <div className="gallery">
      <div className="gallery__strip__wrapper">
        <div className="gallery__strip one">
          <div className="photo">
            <div className="photo__image">
              <Link to="/books">
                <img src="https://s01.static.libri.hu/cover/e0/b/3100215_4.jpg" alt="" />
              </Link>
            </div>
            <div className="photo__name">Toldi<br/>trilógia</div>
          </div>
        </div>
      </div>
      <div className="gallery__strip__wrapper">
  <div className="gallery__strip two">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://dibook.hu/storage/books/pr_3906/cover-big.jpg" alt="" />
        </Link>
      </div>
      <div className="photo__name">Jónás<br/>könyve</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip three">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://s01.static.libri.hu/cover/96/b/3488566_4.jpg" alt=""/>
        </Link>
      </div>
      <div className="photo__name">A vegyész</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip four">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://s01.static.libri.hu/cover/fa/8/709602_4.jpg" alt="" />
        </Link>
      </div>
      <div className="photo__name">Összes<br/>versei</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip five">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://marvin.bline.hu/product_images/592/B1007551.JPG" alt="" />
        </Link>
      </div>
      <div className="photo__name">Goriot<br/>apó</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip six">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://lira.erbacdn.net/upload/M_28/rek1/777/1200777.jpg" alt="" />
        </Link>
      </div>
      <div className="photo__name">Stanley<br/>Kincse</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip seven">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://marvin.bline.hu/product_images/1245/B1064845.JPG" alt="" />
        </Link>
      </div>
      <div className="photo__name">Válogatot<br/>versei</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
      <div className="gallery__strip eight">
        <div className="photo">
          <div className="photo__image">
            <Link to="/books">
              <img src="https://s06.static.libri.hu/cover/86/b/9851949_4.jpg" alt=""   />
            </Link>
          </div>
          <div className="photo__name">Az<br/>utolsó<br/>boszorkány</div>
        </div>
      </div>
    </div>
    <div className="gallery__strip__wrapper">
  <div className="gallery__strip nine">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://p2-ssl.vatera.hu/photos/85/0e/gorog-dramak-e06c_1_big.jpg?v=1" alt="" />
        </Link>
      </div>
      <div className="photo__name">Görög<br/>Drámák</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip ten">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://lira.erbacdn.net/upload/M_28/rek1/572/1309572.jpg" alt="" />
        </Link>
      </div>
      <div className="photo__name">Magyar<br/>helyesírási szótár</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip eleven">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://moly.hu/system/covers/big/covers_327277.jpg?1416343985" alt="" />
        </Link>
      </div>
      <div className="photo__name">Éjjeli<br/>őrjárat</div>
    </div>
  </div>
</div>
<div className="gallery__strip__wrapper">
  <div className="gallery__strip twelve">
    <div className="photo">
      <div className="photo__image">
        <Link to="/books">
          <img src="https://dibook.hu/storage/books/pr_3906/cover-big.jpg" alt="" />
        </Link>
      </div>
      <div className="photo__name">Magyarózdi<br/>toronyalja</div>
    </div>
  </div>
</div>
</div>

  );
}

export default BookGallery;
