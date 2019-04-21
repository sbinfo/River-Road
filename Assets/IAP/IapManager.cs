using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IapManager : MonoBehaviour, IStoreListener
{
        private static IStoreController m_StoreController;    
        private static IExtensionProvider m_StoreExtensionProvider;

        public static string levelIce = "ice";
        public static string levelFantasy = "cosmic";

        void Start()
        {
            if (m_StoreController == null)
            {
                InitializePurchasing();
            }
        }

        public void InitializePurchasing()
        {
            if (IsInitialized())
            {
                // ... we are done here.
                return;
            }

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(levelIce, ProductType.Consumable);
            builder.AddProduct(levelFantasy, ProductType.Consumable);
           // builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);

            UnityPurchasing.Initialize(this, builder);
        }


        private bool IsInitialized()
        {

            return m_StoreController != null && m_StoreExtensionProvider != null;
        }


        // метод купит золото
        public void BuyLevelIce()
        {
            BuyProductID(levelIce);
        }

        // метод купит золото
        public void BuyLevelFantasy()
        {
            BuyProductID(levelFantasy);
        }

        void BuyProductID(string productId)
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productId);

                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));

                    m_StoreController.InitiatePurchase(product);
                }
                else
                {
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }



        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");

            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }


        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {

            if (String.Equals(args.purchasedProduct.definition.id, levelIce, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                PlayerPrefs.SetInt("levelIce", 1);
            }
            else if (String.Equals(args.purchasedProduct.definition.id, levelFantasy, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                PlayerPrefs.SetInt("levelFantasy", 1);
            }
            //else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //}
            //else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //}
            else
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }

            return PurchaseProcessingResult.Complete;
        }


        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
}