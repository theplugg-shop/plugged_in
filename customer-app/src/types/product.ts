export interface ProductSize {
  size: string
  quantity: number
  unitsSold: number
}

export interface Product {
  productId: number
  title: string
  description: string | null
  categoryId: number
  categorySlug: string
  categoryName: string
  subcategorySlug: string | null
  subcategoryName: string | null
  sizes: ProductSize[]
  originalPrice: number
  salePrice: number | null
  discountPercentage: number | null
  isOnSale: boolean
  saleEndsAt: string | null
  rating: number
  images: string[]
  storeId: number
  storeName: string
}
